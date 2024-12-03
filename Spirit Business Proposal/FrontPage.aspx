<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontPage.aspx.cs" Inherits="Spirit_Business_Proposal.FrontPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width,initial-scale=1"/>
        <title>Segra Business Proposal</title>    
        <link href="bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet"/>
        <link href="bower_components/bootstrap/dist/css/bootstrap-theme.min.css" rel="stylesheet"/>
        <link href="bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet"/>
        <link href="css/bootstrap-social.css" rel="stylesheet"/>
        <link href="css/styles.css" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="https://code.jquery.com/ui/1.12.0/themes/smoothness/jquery-ui.css"/>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>       
        <!-- Add Angular to the project -->
        <script src="bower_components/angular/angular.min.js"></script>
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="bower_components/jquery/dist/jquery.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>        
        <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
        <script src ="main.js"></script>
    </head>
    <body>
          <form id="form1" runat="server">
        <!-- Header Content of the Front Page--> 
          
            <div class="container">
                  <div>
                  <div class="col-xs-12 col-sm-4" style="padding-top:40px;">
                      <img style="float:left; width: 181px; height:30px; " src="img/SEGRA_Proposal_App_Logo.png" class="img-responsive"/>
                  </div>
                  <div class="col-xs-12 col-sm-5" style="padding-top:28px;">
                    <div class="form-group row" style="display:inline-block; padding:0px; ">
                        <%-- For Green --%>
                      <%--<label for="Business" class="col-form-label" style=" color:green; font-size:280%; width:100%; font-family:Roboto Black; font-weight:400; margin-left:20px;" > Business Proposal </label>--%>
                        <%-- For Yellow --%>
                      <%--<label for="Business" class="col-form-label" style=" color:#ff6a00; font-size:280%; width:100%; font-family:Roboto Black; font-weight:400; margin-left:20px;" > Business Proposal </label>--%> 
                          <%-- For RED --%>
                        <label for="Business" class="col-form-label" style=" color:#003b70; font-size:280%; width:100%; font-family:Roboto Black; font-weight:400; margin-left:20px;" > Business Proposal </label>
                    </div>                                                  
                  </div>
                      <div class="col-xs-12 col-sm-3" runat="server" id ="replace" style="padding-top:40px;">
                       <input name="Business" style="float:right; color: #a1a8ad; outline:0; border-width: 0 0 1px; border-color:#a1a8ad ;" class="form-control" id="company_name" type="text" runat="server" placeholder="Enter Company Name" required ="required"/>
                     </div>

              </div>
            </div>


        <!-- Body of the Page -->
      <div class="container" style="margin-top:25px;">
        <div class="row-content" style="padding:10px; background-color:#eef1f1">
          <div class="row row-content">   
              <div class="col-xs-12 col-sm-6 border-right" style="">
                 
                  <div class="form-header" style="padding-top:10px; text-align:center; ">
                    <label style="font-size:180%; color:#003b70; font-family:Roboto Medium;" >Representative Details</label>
                  </div>
                  <div class="form-group" style="padding-top:10px;">
                    <label for="name" style="color:#003b70; font-size: 120%; font-family:Roboto Medium;">Name</label>
                    <input type="text" runat ="server" class="form-control" id="name" aria-describedby="name" placeholder="Name" value="" required ="required"/>
                  </div>
                  <div class="form-group" style="padding-top:10px;">
                    <label for="name" style="color:#003b70; font-size: 120%; font-family:Roboto Medium;">Designation</label>
                    <input type="text" runat ="server" class="form-control" id="designation" aria-describedby="designation" placeholder="Designation" required ="required"/>
                  </div>
                  <div class="form-group" style="padding-top:10px;">
                      <label for="date" style="color:#003b70; font-size: 120%; font-family:Roboto Medium;">Date</label>
                       <div class="input-group date" data-provide="datepicker">
                        <input type="text" runat ="server" class="form-control" id="date1" required="required"/>
                            <span class="input-group-addon">
                              <span class="glyphicon glyphicon-th"></span>
                           </span>
                        </div>
                  </div>
                  <div class="form-group" style="padding-top:10px;">
                      <label for="phone" style="color:#003b70; font-size: 120%; font-family:Roboto Medium;">Phone</label>
                      <input type="text" class="form-control" name="phone" runat ="server" id="phone" placeholder="Number" required ="required"/>
                  </div>
                  <div class="form-group"style="padding-top:10px;">
                    <label for="exampleInputEmail1" style="color:#003b70; font-size: 120%; font-family:Roboto Medium;">Email address</label>
                    <input type="email" class="form-control" runat ="server" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" required ="required"/>
                  </div>
                   
                    
              </div>       
              
                      <div class="col-xs-12 col-sm-6">
                          <div class="form-header" style="padding-top:10px; text-align:center; ">
                    <label style="font-size:180%; color:#003b70; font-family:Roboto Medium;" >Customer Location</label>
                  </div>
                        <div>
                          <select class="form-control" name="city" id="form_city" onchange="showData()" runat ="server" style="text-align:center; margin-top:10px;margin-bottom:10px;">
                            <option value="charlotte">Charlotte, NC</option>
                            <option value="ashvile">Asheville, NC</option>
                            <option value="augusta">Augusta, GA</option>
                            <option value="charlsetonsc">Charleston, SC</option>
                            <option  value="charlsetonwv">Charleston, WV</option>                            
                            <option value="charlottesville">Charlottesville, VA</option>
                            <option value="clarksburg">Clarksburg, WV</option>
                            <option value="columbia">Columbia, SC</option>
                            <option value="durham">Durham, NC</option>
                            <option value="frederick">Frederick, MD</option>
                            <option value="fayetteville">Fayetteville, NC</option>
                            <option value="greensboro">Greensboro, NC</option>
                            <option  value="greenvile">Greenville, SC</option>
                            <option value="hagerstown">Hagerstown, MD</option>
                            <option value="harrisonburg">Harrisonburg, VA</option>
                            <option value="huntington">Huntington, WV</option>
                            <option value="leesburg">Leesburg, VA</option>
                            <option value="lynchburg">Lynchburg, VA</option>
                            <option value="morgantown">Morgantown, WV</option>
                            <option value="norfolk">Norfolk, VA</option>
                            <option value="parkersburg">Parkersburg, WV</option>
                            <option value="pittsburg">Pittsburgh, PA</option>
                            <option value="raleigh">Raleigh, NC</option>
                            <option value="richmond">Richmond, VA</option>
                            <option value="roanoke">Roanoke, VA</option>
                            <option value="virginiabeach">Virginia Beach, VA</option>
                            <option value="waynesboro">Waynesboro, VA</option>
                            <option  value="wilmington">Wilmington, NC</option>
                            <option id="dummy" value="xyz" style="visibility:hidden; display:none;">sd</option>
                          </select>
                        </div>
                        <div>
                          <img style="width: 1000px; height: 390px" id="cityimage" src="img/Charlotte_.jpg" runat ="server" class="img-responsive"/>
                        </div>
                      </div>     
                                       
            </div>
            <div class="row row-content" style="text-align:center; padding-top:10px;">
                <asp:Button CssClass="btn btn-primary" ID="createFrontPage" style="font-family: Roboto Regular; " runat="server"  OnCommand="CreateFrontPage" Text="Create Front Page"  />
            </div>
        </div>
       </div>
        </form>

        <!-- Footer of the Front Page -->
        
            <div class="container" style="margin-top:25px; text-align:center; padding: 0 15px !important;">
                <div style="background-color:#001e42;">
                    <label style="padding-top:40px;padding-bottom:40px; font-size:120%; font-family:Roboto Regular; color:#fff;">Segra Proprietary: This information contained here in is for use by authorized only and is not for general distribution</label>
                </div>
            </div>
                 
    </body>
</html>
