<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Web.aspx.cs" Inherits="MvcMovie.Web" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
    </style>
</head>
<body>
    
     <form runat="server" ID="BodyContent" contentplaceholderid="MainContent">
    <script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            var scntDiv = $('#FileUploaders');
            var i = $('#FileUploaders p').size() + 1;

            $('#addUploader').live('click', function () {
                $('<p><input type="file" id="FileUploader' + i + '" name="FileUploader' + i + '" /></label> <a href="#" id="removeUploader">Remove</a></p>').appendTo(scntDiv);
                i++;
                return false;
            });

            $('#removeUploader').live('click', function () {
                if (i > 2) {
                    $(this).parents('p').remove();
                    i--;
                }
                return false;
            });
        });

    </script>
  
       <h3>Upload multiple files to SQL Server Database</h3>
    <div style="padding:10px; border:1px solid black">
        <div id="FileUploaders">
            <p>
                <input type="file" id="FileUploader1" name="FileUploader1" />
            </p>
        </div>
        <a href="#" id ="addUploader" style="font-size:12pt; color:black; text-decoration:underline">Add Another</a>
        <br />
        <asp:Button ID="btnUploadAll" runat="server" Text="Upload File(s)" OnClick="btnUploadAll_Click" />               
    
    </div>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="File name" DataField="FileName" />
            <asp:BoundField HeaderText="File Size" DataField="FileSize" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnDownload" runat="server" CommandName="Download" CommandArgument='<%#Eval("FileID") %>'>
                        Download</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField DataField="Delete" HeaderText="Delete" SortExpression="Delete" />
        </Columns>
    </asp:GridView>
    </form>
        
</body>
</html>