<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="Spirit_Business_Proposal.download" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <!-- The above three meta tags *must* come first in the head; any other head content must
            come *after* these tags  -->
    <title>Segra Business Proposal</title>
    <!-- Bootstrap -->
   <link href="bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
   <link href="bower_components/bootstrap/dist/css/bootstrap-theme.min.css" rel="stylesheet">
   <link href="bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet">
   <link href="css/bootstrap-social.css" rel="stylesheet">
   <link href="css/styles.css" rel="stylesheet">

   <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
   <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
   <!--[if lt IE 9]>
     <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
     <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
   <![endif]-->

</head>
<body>

        <div class="container">
           <div >
               <div class="col-xs-12 col-sm-4" style="padding-top:40px;">
                  <img style="float:left; width: 181px; height:30px;" src="img/SEGRA_Proposal_App_Logo.png" class="img-responsive"/>
                  <!--<img style="float:left; width: 250px;" src="img/main-logo.png" class="img-responsive"/> -->
              </div>
               <div class="col-xs-12 col-sm-5" style="padding-top:28px;">
                  <div class="form-group row" style="display:inline-block; padding:0px; ">
                       <%-- For Green --%>
                      <%--<label for="Business" class="col-form-label" style=" color:green; font-size:280%; width:100%; font-family:Roboto Black; font-weight:400; margin-left:20px;" > Business Proposal </label>--%>
                        <%-- For Yellow --%>
                      <%--<label for="business" class="col-form-label" style=" color:orange; font-size:280%; width:100%; font-family:roboto black; font-weight:400; margin-left:20px;" > Business proposal </label>--%>
                          <%-- For RED --%>
                        <label for="business" class="col-form-label" style=" color:#003b70; font-size:280%; width:100%; font-family:roboto black; font-weight:400; margin-left:20px;" > Business Proposal </label>                 
                  </div>                  
              </div>                
                <div class="col-xs-12 col-sm-3" runat="server" id ="replace" style="padding-top:40px; overflow:auto; text-align:center;">
                  <asp:label runat="server" id="company_name_p" style=" color:#003b70; font-size:180%; width:100%; font-family:Roboto Black; font-weight:300; "/>
                </div>
          </div>
       </div>
    <div class="container" style="margin-top:25px;">
    <div class="row-content" style="padding:20px; background-color:#eef1f1">
    <form id="download" runat="server">
         <div style="display: flex; align-items: center; justify-content: center;">
             <label style="font-size:200%; margin-top:40px; align-items:center; color:#003b70; font-family:Roboto Medium; font-weight:300;"> Do Not Navigate through Website while the File is Downloading</label>
          </div>      
        <div style=" display: flex; align-items: center; justify-content: center; ">
                <asp:Button ID="exportPDF" CssClass="b_middle"  runat="server"   OnCommand="ExportPDf" Style=" margin-top:80px;  border: 2px solid #e7e7e7; border-radius: 12px; background-color: white; font-size:x-large;" CommandArgument="1" Font-Bold="True" Height="150px" Width="400px" Text="Download the Proposal" />
        </div>
        <div style=" display: flex; align-items: center; justify-content: center; ">
                <a href="Frontpage.aspx" style="font-size:200%; margin-top:80px; align-items:center; text-decoration:none; color:orangered;"> Return to the Front Page </a>
        </div>
    </form>
   </div>
    </div>
    <div class="container" style="margin-top:25px; text-align:center; padding: 0 15px !important;">
                <div style="background-color:#001e42;">
                    <label style="padding-top:40px;padding-bottom:40px; font-size:120%; font-family:Roboto Regular; color:#fff;">Segra Proprietary: This information contained here in is for use by authorized only and is not for general distribution</label>
                </div>
            </div>
        <!-- Add Angular to the project -->
        <script src="bower_components/angular/angular.min.js"></script>
          <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
         <script src="bower_components/jquery/dist/jquery.min.js"></script>
         <!-- Include all compiled plugins (below), or include individual files as needed -->
         <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
</body>
</html>
