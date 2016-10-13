<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Changepassword.aspx.cs" Inherits="Changepassword" %>

<%@ Register Src="~/NAV.ascx" TagName="NAV" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" href="images/airmacau.ico" />
    <title>Changepassword</title>


    <%-- css --%>
    <link href="css/style.css" rel="stylesheet" />
    <style>
        .changebox {
            height: 340px;
            width: 340px;
            margin-right: auto;
            margin-left: auto;
            padding: 20px;
            padding-top: 20px;
        }

            .changebox input[type="text"],
            .changebox input[type="password"] {
                border: 1px solid #c8c8c8;
                color: #777;
                font: 13px Helvetica, Arial, sans-serif;
                margin: 0 0 10px;
                padding: 15px 10px 15px 40px;
                width: 240px;
                background: #eae7e7;
                border-radius: 3px;
            }


                .changebox input[type="text"]:focus,
                .changebox input[type="password"]:focus {
                    box-shadow: 0 0 2px #ed1c24 inset;
                    background-color: #fff;
                    border: 1px solid #ed1c24;
                    outline: none;
                }




            .changebox input[type="text"] {
                background: url(../images/8bcLQqF.png) 0 10px no-repeat;
            }


            .changebox input[type="password"] {
                background: url(../images/8bcLQqF.png) 0 -50px no-repeat;
            }

            .changebox a {
                font-size: 22px;
                font-family: Arial, Helvetica, sans-serif;
            }

        #Save {
            border-radius: 3px;
            color: #444;
            width: 82px;
            height: 32px;
            border: 0px;
            float: none;
            display: inline-block;
            font-size: 11px;
            font-weight: bold;
            text-decoration: none;
            background-color: #382649;
            text-shadow: 0 1px rgba(255, 255, 255, .75);
            cursor: pointer;
            margin-bottom: 20px;
            line-height: 21px;
            color: #ffffff;
            font-family: "HelveticaNeue", "Helvetica Neue", Helvetica, Arial, sans-serif;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:NAV ID="NAV" runat="server" />
        </div>
        <div class="mainbody">
            <div class="bodydiv">
                <div class="changebox">
                    <a>Change Password
                    </a>
                    <div style="margin-top: 20px">
                        <input type="text" placeholder="Username" id="username" disabled="disabled" runat="server" />
                    </div>
                    <div>
                        <input type="password" placeholder="Password" required="required" id="password" runat="server" />
                    </div>
                    <div>
                        <input type="password" placeholder="Password" required="required" id="password1" runat="server" />
                    </div>
                    <div>
                        <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
