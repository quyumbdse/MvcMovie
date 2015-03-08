using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcMovie
{
    public partial class Web : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.Enctype = "multipart/form-data"; // this is required to enable multi file upload
            if (!IsPostBack)
            {
                PopulateUploadedFiles();
            }
        }
        private void PopulateUploadedFiles()
        {
            // Populate data 
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                GridView1.DataSource = dc.UploadedFiles.ToList();
                GridView1.DataBind();
            }
        }
        protected void btnUploadAll_Click(object sender, EventArgs e)
        {
            HttpFileCollection filesColl = Request.Files;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                foreach (string uploader in filesColl)
                {
                    HttpPostedFile file = filesColl[uploader];

                    if (file.ContentLength > 0)
                    {
                        BinaryReader br = new BinaryReader(file.InputStream);

                        byte[] buffer = br.ReadBytes(file.ContentLength);

                        dc.UploadedFiles.Add(new UploadedFiles
                        {
                            FileId = 0,
                            FileName = file.FileName,
                            ContentType = file.ContentType,
                            FileExtention = Path.GetExtension(file.FileName),
                            FileSize = file.ContentLength,
                            FileContent = buffer
                        });
                    }
                }
                dc.SaveChanges();
            }
            PopulateUploadedFiles(); // for refress grid data
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Add code for download files
            if (e.CommandName == "Download")
            {
                int fileID = Convert.ToInt32(e.CommandArgument.ToString());
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    var v = dc.UploadedFiles.Where(a => a.FileId.Equals(fileID)).FirstOrDefault();
                    if (v != null)
                    {
                        Response.ContentType = v.ContentType;
                        Response.AddHeader("content-disposition", "attachment; filename=" + v.FileName);
                        Response.BinaryWrite(v.FileContent);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }

    }
}