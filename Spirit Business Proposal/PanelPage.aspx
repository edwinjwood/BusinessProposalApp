<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelPage.aspx.cs" Inherits="Spirit_Business_Proposal.PanelPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <!-- Add Angular to the project -->
        <script src="bower_components/angular/angular.min.js"></script>
         <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="bower_components/jquery/dist/jquery.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script> 
    <script type="text/javascript">
        function UploadFilePop() {
            $('#popForProposal').modal('show');
        }
        function showThumbnail(id) {
            
            var errorLabel = document.getElementById("ErrorLabel");
            var aspFileUpload = document.getElementById(id);
            var fileName = aspFileUpload.value;
            var ext = fileName.substr(fileName.lastIndexOf('.') + 1).toLowerCase();
            console.log("I" + ext);
            if (ext == "jpeg" || ext == "jpg" || ext == "png") {
                errorLabel.innerHTML = "";
            }
            else {
                console.log("inside filecheck function 1");
                errorLabel.innerHTML = "Invalid image file, must select a *.jpeg, *.jpg, or *.png file.";
                aspFileUpload.value = "";
            }
            if (aspFileUpload.files[0].size > 3145728) {
                console.log("inside filecheck function 2");
                errorLabel.innerHTML += "File is too large, must select file under 3 Mb. <br>";
                aspFileUpload.value = "";
            }
        }

        function checkIfPdf(id) {
            var errorLabel = document.getElementById("ErrorLabel2");
            var aspFileUpload = document.getElementById(id);
            var fileName = aspFileUpload.value;
            var ext = fileName.substr(fileName.lastIndexOf('.') + 1).toLowerCase();
            console.log("I" + ext);
            if (ext == "pdf" ) {
                errorLabel.innerHTML = "";
            }
            else {
                errorLabel.innerHTML = "Invalid pdf file, must select a *.pdf file.";
                aspFileUpload.value = "";
            }
            if (aspFileUpload.files[0].size > 3145728) {
                console.log("inside filecheck function 2");
                errorLabel.innerHTML += "File is too large, must select file under 3 Mb. <br>";
                aspFileUpload.value = "";
            }
        }

        function checkIfProposedPdf(id) {
            var errorLabel = document.getElementById("ErrorLabel3");
            var aspFileUpload = document.getElementById(id);
            var fileName = aspFileUpload.value;
            var ext = fileName.substr(fileName.lastIndexOf('.') + 1).toLowerCase();
            console.log("I" + ext);
            if (ext == "pdf") {
                errorLabel.innerHTML = "";
            }
            else {
                errorLabel.innerHTML = "Invalid pdf file, must select a *.pdf file.";
                aspFileUpload.value = "";
            }
            if (aspFileUpload.files[0].size > 3145728) {
                console.log("inside filecheck function 2");
                errorLabel.innerHTML += "File is too large, must select file under 3 Mb. <br>";
                aspFileUpload.value = "";
            }
        }
</script>
</head>
<body>
            <form runat="server">
      
        <div class="container">
          <div>
              <div class="col-xs-12 col-sm-4" style="padding-top:40px;">
                  <img style="float:left; width: 181px; height:30px;" src="img/SEGRA_Proposal_App_Logo.png" class="img-responsive"/>
                  <!--<img style="float:left; width: 250px;" src="img/main-logo.png" class="img-responsive"/> -->
              </div>
              <div class="col-xs-12 col-sm-5" style="padding-top:28px;">
                  <div class="form-group row" style="display:inline-block; padding:0px; ">
                       <%-- For Green --%>
                      <%--<label for="Business" class="col-form-label" style=" color:green; font-size:280%; width:100%; font-family:Roboto Black; font-weight:400; margin-left:20px;" > Business Proposal </label>--%>
                        <%-- For Yellow --%>
                        <%--<label for="Business" class="col-form-label" style=" color:#ff6a00; font-size:280%; width:100%; font-family:Roboto Black; font-weight:400; margin-left:20px;" > Business Proposal </label> --%>
                          <%-- For RED --%>
                        <label for="Business" class="col-form-label" style=" color:#003b70; font-size:280%; width:100%; font-family:Roboto Black; font-weight:400; margin-left:20px;" > Business Proposal </label>     
                  </div>                  
              </div>
              <div class="col-xs-12 col-sm-3" runat="server" id ="replace" style="padding-top:40px; overflow:auto; text-align:center;">
                <asp:label id="company_name" runat="server" style=" color:#003b70; font-size:180%; width:100%; font-family:Roboto Black; font-weight:300; "/>
              </div>                   
                
          </div>
        </div>
        <div class="container" style="margin-top:25px; background-color:#eef1f1">
            <%--<div class="row-content" style="padding:20px; background-color:#eef1f1">--%>

                  <div style="padding:20px; text-align:center;">
                    <label style=" font-size:180%; color:#003b70; font-family:Roboto Medium;"> Contents</label>
                      <input type="text" runat="server" style="visibility:hidden;display:none" value="gettttttt" id="gettingCompName"/>
                  </div>
                
            <div class="row">

                <div class="col-xs-15 col-sm-3">
                  <div class="panel panel-default" style="width: 20rem; min-height:220px;">
                    <div class="panel-heading">
                      Table of Contents
                    </div>
                    <div class="panel-body">
                        <p class="card-text"><input type="checkbox" runat="server" id="tableContent" checked="checked" /> Include in the Proposal</p> 
                        <button id="Button5" type="button" class="btn btn-sm btn-default pull-right" style="background-color:white; visibility:hidden" runat="server">
                             Add
                        </button>
                                             
                    </div>
                    </div>
                  </div>

                  <div class="col-xs-15 col-sm-3">
                  <div class="panel panel-default" style="width: 20rem; min-height:220px;">
                    <div class="panel-heading" style="background-color:red;">
                      Why Segra
                    </div>
                    <div class="panel-body">
                      <p class="card-text"><input type="checkbox" runat="server" id="Executive_Summary" checked="checked" disabled="disabled"/> Included in the Proposal</p> 
                        
                        <p class="card-text"><input type="checkbox" runat="server" id="IncludeCoverWhoWeAre" checked="checked" /> Include Divider</p>  
                        <button id="Button4" type="button" class="btn btn-sm btn-default pull-right" runat="server" data-toggle="modal" data-target="#popForWhoWeAre" style="margin-top:53px;">
                            Add Content
                        </button>
                        <div class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" id="popForWhoWeAre" >
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Select the Pages to Include</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group ">
                                            <label>  <input runat="server" id="WelcometoSegra" type="checkbox" checked="checked" disabled="disabled"/> Welcome to Segra </label>
                                        </div>
                                        
                                        <div class="form-group">
                                            <label> <input runat="server" id="ArticlesofExcellence" type="checkbox" checked="checked" disabled="disabled"/> Articles of Excellence </label>                                      
                                       </div>
                                        <div class="form-group">
                                            <label> <input runat="server" id="RedifiningDelivery" type="checkbox" checked="checked" disabled="disabled"/> Redefining Delivery </label>                                      
                                       </div>
                                        <div class="form-group">
                                            <label> <input runat="server" id="CSC_KPIWhySegra" type="checkbox" /> CSC KPI </label>                                      
                                       </div>
                                        <div class="form-group">
                                            <label> <input runat="server" id="CSRWhySegra" type="checkbox"  /> Customer Satisfaction Report</label>                                      
                                       </div>
                                        <div class="form-group">
                                            <label> <input runat="server" id="InTheCommunitySC" type="checkbox"/> In The Community - SC </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" id="InTheCommunityNC" type="checkbox"/> In The Community - NC </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" id="InTheCommunityMD" type="checkbox"/> Our Commitment - MD </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" id="InTheCommunityPA" type="checkbox"/> Our Commitment - PA </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" id="InTheCommunityVA" type="checkbox"/> Our Commitment - VA </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" id="InTheCommunityWV" type="checkbox"/> Our Commitment - WV </label>
                                        </div>                                           
                                       </div>
                                    <div class="modal-footer">
                                        <button id="btnWhoweAre" class="btn btn-primary" onclick="InsertWhoWeAre()"  runat="server" >Insert</button>
                                        <button class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>                    
                    </div>
                    </div>
                  </div>

                  <div class ="col-xs-15 col-sm-3">
                      <div class="panel panel-default" style="width: 20rem; min-height:220px;">
                    <div class="panel-heading">
                      Testimonials 
                    </div>
                    <div class="panel-body">
                        <p class="card-text"><input type="checkbox" runat="server" id="includePortfolio" checked="checked" /> Included in the Proposal</p>  
                        <%--<p class="card-text"><input type="checkbox" runat="server" id="Checkbox2" checked="checked" /> Include Divider </p>--%>  
                        <button type="button" class="btn btn-sm btn-default pull-right" runat="server" data-toggle="modal" data-target="#popPortfolio" style="margin-top:82px;">
                            Add Content
                        </button>
                        <div class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" id="popPortfolio" >
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Select the Testimonials to be included </h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group div1">
                                            <label class="form-control">  <input runat="server" type="checkbox" id="BigRedBox"/> Big Red Box </label>
                                            <div class="headingCheckbox">
                                                <p> Solutions: Fiber - Secure LTE Backup - Hosted Voice - Call Center</p>
                                                <p> Highlights: Customer Service - Increased Business Results - Understanding Customer Needs</p>
                                            </div>
                                        </div>
                                        <div class="form-group div1">
                                            <label class="form-control">  <input runat="server" type="checkbox" id="ColumbiaFireflies"/> Columbia Fireflies </label>
                                            <div class="headingCheckbox">
                                                <p> Solutions: Fiber - Hosted Firewall - Wi-Fi - Hosted Voice</p>
                                                <p> Highlights: Large Project Development - Large Venue - Partner Commitment</p>
                                            </div>
                                        </div>
                                        <div class="form-group div1">
                                            <label class="form-control">  <input runat="server" type="checkbox" id="CommWellHealth"/> CommWell Health </label>
                                            <div class="headingCheckbox">
                                                <p> Solutions: Fiber - Secure LTE Backup - Managed Firewall - Managed Router</p>
                                                <p> Highlights: Reduction of Service Providers - Redundant Connectivity - Multi-Site Locations - IT Cost Savings</p>
                                            </div>
                                        </div>
                                        <div class="form-group div1">
                                            <label class="form-control">  <input runat="server" type="checkbox" id="IGSIndustries"/> IGS Industries </label>
                                            <div class="headingCheckbox">
                                                <p> Solutions: Fiber</p>
                                                <p> Highlights: Fast Service Response - Customer Service - Long-Standing Relationships</p>
                                            </div>
                                        </div>
                                        <div class="form-group div1">
                                            <label class="form-control">  <input runat="server" type="checkbox" id="LoundonUnitedFC"/> Loudoun United FC </label>
                                            <div class="headingCheckbox">
                                                <p> Solutions: Fiber - Hosted Voice - Wi-Fi - Hosted Firewall </p>
                                                <p> Highlights: Fast Turn-up - Large Product Commitment - Full Suite of Solutions</p>
                                            </div>
                                        </div>
                                        <div class="form-group div1">
                                            <label class="form-control">  <input runat="server" type="checkbox" id="MembersCreditUnion"/> Members Credit Union </label>
                                            <div class="headingCheckbox">
                                                <p> Solutions: Fiber - Hosted Voice - Wi-Fi - Hosted Firewall </p>
                                                <p> Highlights: Fast Turn-up - Large Product Commitment - Full Suite of Solutions</p>
                                            </div>
                                        </div>
                                        <div class="form-group div1">
                                            <label class="form-control">  <input runat="server" type="checkbox" id="PinnacleTrailers"/> Pinnacle Trailers </label>
                                            <div class="headingCheckbox">
                                                <p> Solutions: Fiber - Hosted Voice </p>
                                                <p> Highlights: Fiber Footprint - Company Values - Cloud - Long-Standing Relationships </p>
                                            </div>
                                        </div>
                                        <div class="form-group div1">
                                            <label class="form-control">  <input runat="server" type="checkbox" id="RadiologyAssociatesOfRichmond"/> Radiology Associates Of Richmond </label>
                                            <div class="headingCheckbox">
                                                <p> Solutions: Fiber - Data Center - PRI Voice to SIP - VPRN - SOCaaS </p>
                                                <p> Highlights: Customer Support - Multi-Site Locations/Expansive Footprint - Future Product Conversion Planning - Healthcare Security Needs </p>
                                            </div>
                                        </div>
                                        <div class="form-group div1">
                                            <label class="form-control">  <input runat="server" type="checkbox" id="RossMouldLLC"/> Ross Mould LLC </label>
                                            <div class="headingCheckbox">
                                                <p> Solutions: Fiber - DIA - DDoS - Hosted Voice - Site-to-Site VPN </p>
                                                <p> Highlights: SMB Services - POTS Transition </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button class="btn btn-primary"  runat="server" onclick="InsertTestimonials()">Insert</button>
                                        <button class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>

                  </div>

                  <div class="col-xs-15 col-sm-3">
                  <div class="panel panel-default" style="width: 20rem; min-height:220px;">
                    <div class="panel-heading">
                      Custom Content Upload
                    </div>
                    <div class="panel-body">
                        <p class="card-text"><input type="checkbox" runat="server" id="Obectives" checked="checked" /> Included in the Proposal</p>  
                        <p class="card-text"><input type="checkbox" runat="server" id="IncludeCoverSolution" checked="checked" /> Include Divider </p>  
                        <p class="card-text" id="P1" style="display:none;" runat="server"><input type="checkbox" runat="server" id="includeCustomContent"/> Include Document </p>
                        <asp:Label ID="LabelObjective" runat="server" Text="No File Uploaded" style="color:red;"></asp:Label>
                        <button type="button" class="btn btn-sm btn-default pull-right" runat="server" data-toggle="modal" data-target="#popForObjective" style="margin-top:30px;">
                            Add Content
                        </button>
                        <div class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" id="popForObjective" >
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Upload PDF documents to be inserted.</h4>
                                    </div>
                                    <div class="modal-body">
                                        <label  style="text-align:left; margin-top:10px;margin-bottom:10px;">Upload up to 3 PDF documents <br> <span style="color:red;"> * Maximum File Size 2MB Only. </span> <br />
                                            <span style="color:red;"> Combined file upload size must be 5mb or less. </span> </label>
                                        <asp:Label ID="ErrorLabel2" runat="server" style="color:red;" Text=""></asp:Label>
                                        <%--<select class="form-control" name="form_page" id="form_page" onchange="addformpage()" runat="server" style="text-align:center; margin-top:10px;margin-bottom:10px;">
                                          <option value="1" selected="selected">1</option>
                                          <option value="2">2</option>
                                          <option value="3">3</option>
                                          <option value="4">4</option>
                                        </select>--%>
                                        <%--<textarea class="form-control" runat="server" maxlength="3500" id="objective" style="min-width: 100%; margin-top:10px;margin-bottom:10px;" rows="11" value="Insert Content for objective form 1"></textarea>
                                        <textarea class="form-control" runat="server" maxlength="3500" id="objective2" name="hide" style="display:none; min-width: 100%; margin-top:10px;margin-bottom:10px;" rows="11" value="Insert Content for objective form 2"></textarea>
                                        <textarea class="form-control" runat="server" maxlength="3500" id="objective3" name="hide" style="display:none; min-width: 100%; margin-top:10px;margin-bottom:10px;" rows="11" value="Insert Content for objective form 3"></textarea>
                                        <textarea class="form-control" runat="server" maxlength="3500" id="objective4" name="hide" style="display:none; min-width: 100%;margin-top:10px;margin-bottom:10px;" rows="11" value="Insert Content for objective form 4"></textarea>--%>
                                        <div class="form-group row" style="margin-top:10px;margin-bottom:10px; margin-left:10px;">
                                            <asp:FileUpload ID="FileUploadCustomContent1" runat="server" onchange="Javascript: checkIfPdf(this.id);" ToolTip="Select Only PDF File"  AllowMultiple="false"/> 
                                        </div>
                                        <div class="form-group row" style="margin-top:10px;margin-bottom:10px;margin-left:10px;">
                                            <asp:FileUpload ID="FileUploadCustomContent2" runat="server" onchange="Javascript: checkIfPdf(this.id);" ToolTip="Select Only PDF File" AllowMultiple="false"/> 
                                        </div>
                                        <div class="form-group row" style="margin-top:10px;margin-bottom:10px;margin-left:10px;">
                                            <asp:FileUpload ID="FileUploadCustomContent3" runat="server" onchange="Javascript: checkIfPdf(this.id);" ToolTip="Select Only PDF File" AllowMultiple="false"/> 
                                        </div>
                                        <asp:Label ID="listofCustomContentFile" runat="server" /> 
                                    </div>
                                    <div class="modal-footer">
                                        <%--<button class="btn btn-primary"  runat="server" onclick="InsertTheContent()">Insert</button>--%>
                                        <asp:Button class="btn btn-primary" ID="btnUploadCustomContent" runat="server" Text="Upload" OnClick="UploadCustomContentFile"/>
                                        <button class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                  </div>

                  <div class="col-xs-15 col-sm-3">
                  <div class="panel panel-default" style="width: 20rem; min-height:220px;">
                    <div class="panel-heading">
                      Solutions
                    </div>
                    <div class="panel-body">
                      <p class="card-text"><input type="checkbox" runat="server" id="solution" checked="checked" disabled="disabled"/> Included in the Proposal</p>
                        <button type="button" class="btn btn-sm btn-default pull-right" runat="server" data-toggle="modal" data-target="#popForSolution" style="margin-top:82px;">
                            Add Content
                        </button>
                        <div class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" id="popForSolution" >
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Select the solutions to include</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="algoLoudSpeakerPaging"/> Algo LoudSpeaker Paging </label>
                                        </div>
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="baas"/> BaaS </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="colocation"/> Colocation </label>
                                         </div> 
                                        <div class="form-group">
                                             <label> <input runat="server" type="checkbox" id="contactCenter"/>  Contact Center </label>
                                         </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="convergedVoice"/> Converged Voice</label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="ddosEdgeProtect"/> DDoS Edge Protect </label>                                      
                                       </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="dedicatedInternetAccess"/> Dedicated Internet Access </label>
                                        </div>
                                        <div class="form-group">
                                             <label> <input runat="server" type="checkbox" id="dRaaS"/> DRaaS </label>
                                         </div>
                                        <%--<div class="form-group">
                                             <label> <input runat="server" type="checkbox" id="dynamicBundle"/> Dynamic Bundle </label>
                                         </div>--%>
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="ethernetService"/> Ethernet Service </label>
                                        </div>
                                        <div class="form-group">
                                             <label> <input runat="server" type="checkbox" id="expressCloudAccess"/> Express Cloud Access </label>
                                         </div>
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="extensiveFiberNetwork"/> Extensive Fiber Network </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="hostedFirewall"/> Hosted Firewall </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="hostedHdVoice"/> Hosted HD Voice </label> 
                                        </div>
                                        <div class="form-group">
                                             <label> <input runat="server" type="checkbox" id="iaas"/> IaaS </label>
                                         </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="ipFax"/> IP Fax </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="lTeSecureAccess"/> LTE Secure Access </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="lTESecureBackup"/> LTE Secure Backup </label>
                                        </div>
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="managedRouter"/> Managed Router </label>
                                        </div>
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="managedSwitch"/> Managed Switch </label>
                                        </div>
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="managedWifi"/> Managed Wifi </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="mobileVoice"/> Mobile Voice </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="mpls"/> MPLS </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="musicOnHold"/> Music On Hold </label>
                                        </div>
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="onDemandConferencing"/> On Demand Conferencing </label>
                                        </div>
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="privateLine"/> Private Line </label>
                                        </div>
                                        <div class="form-group ">
                                            <label>  <input runat="server" type="checkbox" id="remoteOfficeLAN"/> Remote Office LAN </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input type="checkbox" runat="server" id="sdwan"/> SDWAN </label>
                                        </div>
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="segraHealthCareNetwork"/> Segra Healthcare Network </label>
                                        </div>                                        
                                        <div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="sipFlex"/> SIP Flex </label>
                                        </div>
                                        <div class="form-group">
                                             <label> <input runat="server" type="checkbox" id="sOCaaS"/> SOCaaS </label>
                                         </div>
                                        <div class="form-group">
                                             <label> <input runat="server" type="checkbox" id="unify"/> Unify </label>
                                         </div>
                                        <%--<div class="form-group">
                                            <label> <input runat="server" type="checkbox" id="unlimitedBundle"/> Unlimited Bundle </label>
                                         </div>--%>

                                        
                                        <div class="form-group"> 
                                            <label> <input runat="server" type="checkbox" id="vPRN"/> VPRN </label>
                                        </div>
                                                                                     
                                       </div>
                                    <div class="modal-footer">
                                        <button id="Button2" class="btn btn-primary" onclick="InsertSolution()"  runat="server" >Insert</button>
                                        <button class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                  </div>

                  
                </div>
            <div class="row">
                <div class="col-xs-15 col-sm-3">
                  <div class="panel panel-default" style="width: 20rem; min-height:220px;">
                    <div class="panel-heading">
                      Implementation
                    </div>
                    <div class="panel-body">
                      <p class="card-text"><input type="checkbox" runat="server" id="implementation" checked="checked" disabled="disabled"/> Included in the Proposal</p>
                        <p class="card-text"><input type="checkbox" runat="server" id="IncludeImplementationCover" checked="checked" /> Include Divider </p>  
                      <button id="Button1" type="button" class="btn btn-sm btn-default pull-right" runat="server" data-toggle="modal" data-target="#implementaionPopup" style="margin-top:53px;">
                            Add Content
                        </button>
                         <div class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" id="implementaionPopup" >
                            <div class="modal-dialog modal-xl">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title"> Implementation Specifics </h4>
                                    </div>
                                    <div class="modal-body">
                                        <label style="color:red;">Key Account Level Contacts: Fill in the first and last name of the "Authority Name" fields only. The remaining contact data will auto-populate after clicking insert. </label>
                                        <table class="table table-striped" id="Table2">
                                            <thead id="Thead2">
                                              <tr>
                                                <th class="text-center">Authority Name</th>
                                                <th class="text-center">Authority Title</th>
                                                <th class="text-center">Authority Contact</th>
                                                <th class="text-center">Authority Email</th>
                                              </tr>
                                            </thead>
                                            <tbody>
                                              <tr><td><asp:TextBox class="form-control" runat="server" OnTextChanged="accountExecutiveName1_TextChanged"  id="accountExecutiveName1" placeholder="Account Executive Name" ></asp:TextBox></td>
                                                <td><asp:TextBox class="form-control" runat="server" id="titleAE1" placeholder="Title Account Executive" ></asp:TextBox></td>
                                                <td ><input type="text" class="form-control" runat="server" id="AEContactNumber" placeholder="Account Executive Phone" /></td>
                                                <td class="email"><input type="email" class="form-control" runat="server" id="AEEmail" placeholder="Account Executive Email" /></td>
                                              </tr>
                                              <tr><td><asp:TextBox class="form-control" runat="server" OnTextChanged="salesEng1_TextChanged" id="salesEng1" placeholder="Sales Engineer/TC Name" ></asp:TextBox></td>
                                                <td><input type="text" class="form-control" runat="server" id="titleSE" placeholder="Title Sales Engineer" /></td>
                                                <td ><input type="text" class="form-control" runat="server" id="SENumber" placeholder="Sales Executive Phone" /></td>
                                                <td class="email"><input type="email" class="form-control" runat="server" id="SEEmail" placeholder="Sales Executive Email" /></td>
                                              </tr>
                                              <tr><td><asp:TextBox class="form-control" runat="server" OnTextChanged="salseSupportSpecialistName1_TextChanged" id="salseSupportSpecialistName1" placeholder="Sales Support Executive Name" ></asp:TextBox></td>
                                                <td><input type="text" class="form-control" runat="server" id="titleSalseSupportSpecialist" placeholder="Title Sales Support Specialist" /></td>
                                                <td ><input type="text" class="form-control" runat="server" id="SSENumber" placeholder="Sales Support Executive Phone" /></td>
                                                <td class="email"><input type="email" class="form-control" runat="server" id="SSEEmail" placeholder="Sales Support Executive Email" /></td>
                                              </tr>
                                                <tr><td><asp:TextBox class="form-control" runat="server" OnTextChanged="regionalSalseManagerName1_TextChanged" id="regionalSalseManagerName1" placeholder="Regional Sales Director Name" ></asp:TextBox></td>
                                                <td><input type="text" class="form-control" runat="server" id="titleRegionalSalseManager" placeholder="Title Regional Sales Director" /></td>
                                                <td ><input type="text" class="form-control" runat="server" id="RSMENumber" placeholder="Regional Sales Director Phone" /></td>
                                                <td class="email"><input type="email" class="form-control" runat="server" id="RSMEEmail" placeholder="Regional Sales Director Email" /></td>
                                              </tr>
                                                <tr><td><asp:TextBox class="form-control" runat="server" OnTextChanged="directorSalseName1_TextChanged" id="directorSalseName1" placeholder="VP of Sales Name"></asp:TextBox></td>
                                                <td><input type="text" class="form-control" runat="server" id="titleDirectorSalse" placeholder="Title VP of Sales"/></td>
                                                <td ><input type="text" class="form-control" runat="server" id="DSNumber" placeholder="VP Sales Phone" /></td>
                                                <td class="email"><input type="email" class="form-control" runat="server" id="DSEmail" placeholder="VP Sales Email" /></td>
                                              </tr>
                                                <tr><td><asp:TextBox class="form-control" runat="server" OnTextChanged="chiefMarketingOfficer1_TextChanged" id="chiefMarketingOfficer1" placeholder="Chief Revenue Officer" ></asp:TextBox></td>
                                                <td><input type="text" class="form-control" runat="server" id="titleChiefMarketingOfficer" placeholder="Title Chief Revenue Officer" /></td>
                                                <td ><input type="text" class="form-control" runat="server" id="CMONumber" placeholder="Chief Revenue Officer Phone" /></td>
                                                <td class="email"><input type="email" class="form-control" runat="server" id="CMOEmail" placeholder="Chief Revenue Officer Email" /></td>
                                              </tr>
                                            </tbody>
                                          </table>
                                        
                                    </div>
                                    <div class="modal-footer">
                                        <button id="Button3" class="btn btn-primary" onclick="InsertImplementation()"  runat="server">Insert</button>
                                        <button class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>   
                    </div>
                    </div>
                  </div>
                <div class="col-xs-15 col-sm-3">
                  <div class="panel panel-default" style="width: 20rem; min-height:220px;">
                    <div class="panel-heading">
                      Implementation Images 
                    </div>
                    <div class="panel-body">
                        <p class="card-text"><input type="checkbox" runat="server" id="ObjectivesImg" checked="checked" /> Included in the Proposal</p>
                         <asp:Label ID="Label1" runat="server" Text="No File Uploaded" style="color:red;"></asp:Label> 
                        <button id="Button8" type="button" class="btn btn-sm btn-default pull-right" runat="server" data-toggle="modal" data-target="#popForObjectiveImg" style="margin-top:82px;">
                            Add Content
                        </button>
                        <div class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" id="popForObjectiveImg" >
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Write the Content to be Inserted Here</h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="ErrorLabel" runat="server" style="color:red;" Text=""></asp:Label>
                                        <label  style="text-align:center; margin-top:10px;margin-bottom:10px;">Number of Images Page to be used </label>
                                        <select class="form-control" name="form_Img" id="form_Img" onchange="addImgpage()" runat="server" style="text-align:center; margin-top:10px;margin-bottom:10px;">
                                          <option value="1" selected="selected">1</option>
                                          <option value="2">2</option>
                                          <option value="3">3</option>
                                          <option value="4">4</option>
                                          <option value="5">5</option>
                                        
                                        </select>
                                        <div id="div_img1" class="form-group row" style="margin-top:10px;margin-bottom:10px;">
                                        <div class="col-xs-5"> 
                                            <asp:FileUpload ID="ImageUploadPage1" onchange="Javascript: showThumbnail(this.id);" runat="server" ToolTip="Select Only Image File" AllowMultiple="false"/>    </div>
                                            <div class="col-xs-7">
                                             <input class="form-control" runat="server"  id="img1" value="Title for Page 1" />
                                                </div>
                                        </div>

                                        <div id="div_img2" class=" form-group row" style="margin-top:10px;margin-bottom:10px; display:none;">
                                            <div class="col-xs-5">
                                                <asp:FileUpload ID="ImageUploadPage2" onchange="Javascript: showThumbnail(this.id);"  runat="server" ToolTip="Select Only Image File" AllowMultiple="false"/> 
                                            </div>
                                            <div class="col-xs-7">
                                                <input class="form-control" runat="server"  id="img2" style="margin-top:10px;margin-bottom:10px;" value="Title for Page 2"/>
                                            </div>
                                        </div>

                                        <div id="div_img3" class=" form-group row" style="margin-top:10px;margin-bottom:10px; display:none;">
                                            <div class="col-xs-5">
                                                <asp:FileUpload ID="ImageUploadPage3" onchange="Javascript: showThumbnail(this.id);" runat="server" ToolTip="Select Only Image File" AllowMultiple="false"/> 
                                            </div>
                                            <div class="col-xs-7">
                                                <input class="form-control" runat="server"  id="img3" style="margin-top:10px;margin-bottom:10px;" value="Title for Page 3"/>
                                            </div>
                                        </div>
                                        
                                        <div id="div_img4" class=" form-group row" style="margin-top:10px;margin-bottom:10px; display:none;">
                                            <div class="col-xs-5">
                                                <asp:FileUpload ID="ImageUploadPage4" onchange="Javascript: showThumbnail(this.id);" runat="server" ToolTip="Select Only Image File" AllowMultiple="false"/> 
                                            </div>
                                            <div class="col-xs-7">
                                                <input class="form-control" runat="server"  id="img4" style="margin-top:10px;margin-bottom:10px;" value="Title for Page 4"/>
                                            </div>
                                        </div>

                                        <div id="div_img5" class=" form-group row" style="margin-top:10px;margin-bottom:10px; display:none;">
                                            <div class="col-xs-5">
                                                <asp:FileUpload ID="ImageUploadPage5" onchange="Javascript: showThumbnail(this.id);" runat="server" ToolTip="Select Only Image File" AllowMultiple="false"/> 
                                            </div>
                                            <div class="col-xs-7">
                                                <input class="form-control" runat="server"  id="img5" style="margin-top:10px;margin-bottom:10px;" value="Title for Page 5"/>
                                            </div>
                                        </div>                                        
                                        <asp:Label ID="ListOfImagesToUpload" runat="server" /> 
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button class="btn btn-primary" ID="buttonImageUploadPage1" runat="server" Text="Upload" OnClick="UploadImagePage1"  />
                                        <button class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                  </div>

                <div class="col-xs-15 col-sm-3">
                  <div class="panel panel-default" style="width: 20rem; min-height:220px;">
                    <div class="panel-heading">
                      Pricing Upload  
                    </div>
                    <div class="panel-body">
                        <p class="card-text"><input type="checkbox" runat="server" id="proposal" checked="checked" /> Included in the Proposal</p>
                        <p class="card-text"><input type="checkbox" runat="server" id="IncludeProposalCover" checked="checked" /> Include Divider </p>
                        <p class="card-text" id="showIncludeProp" style="display:none;" runat="server"><input type="checkbox" runat="server" id="IncludeProposalDoc"  /> Include Document </p> 
                        <asp:Label ID="Label2" runat="server" Text="No File Uploaded" style="color:red;"></asp:Label> 
                        
                        <button id="Button10" type="button" class="btn btn-sm btn-default pull-right" runat="server" data-toggle="modal" data-target="#popForProposal" style="margin-top:30px; margin-bottom:0px;">
                            Add Content
                        </button>
                        <div class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" id="popForProposal" >
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Include the PDF here</h4>                                        
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="ErrorLabel3" runat="server" style="color:red;" Text=""></asp:Label>
                                        <label  style="text-align:left; margin-top:10px;margin-bottom:10px;">Upload upto 3 PDF <br> <span style="color:red;"> * Maximum File Size 2MB Only. </span> <br />
                                            <span style="color:red;"> Combined file upload size must be 5mb or less. </span>
                                        </label>
                                        <div class="form-group row" style="margin-top:10px;margin-bottom:10px; margin-left:10px;">                                        
                                            <asp:FileUpload ID="PricingUpload1" runat="server" onchange="Javascript: checkIfProposedPdf(this.id);" ToolTip="Select Only PDF File" AllowMultiple="true"/> 
                                        </div>
                                        <div class="form-group row" style="margin-top:10px;margin-bottom:10px; margin-left:10px;">                                        
                                            <asp:FileUpload ID="PricingUpload2" runat="server" onchange="Javascript: checkIfProposedPdf(this.id);" ToolTip="Select Only PDF File" AllowMultiple="true"/> 
                                        </div>
                                        <div class="form-group row" style="margin-top:10px;margin-bottom:10px; margin-left:10px;">                                        
                                            <asp:FileUpload ID="PricingUpload3" onchange="Javascript: checkIfProposedPdf(this.id);" runat="server" ToolTip="Select Only PDF File" AllowMultiple="true"/> 
                                        </div>                                        

                                        <asp:Label ID="listOfUploadedFiles" runat="server"/>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button class="btn btn-primary" ID="btnImageUpload" runat="server" Text="Upload" OnClick="UploadFile"  />
                                        <%--<button id="Button11" class="btn btn-primary"  runat="server" onclick="InsertTheProposal()">Insert</button>--%>
                                        <button class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                  </div>


                  <div class="col-xs-15 col-sm-3">
                  <div class="panel panel-default" style="width: 20rem; min-height:220px;">
                    <div class="panel-heading">
                      References
                    </div>
                    <div class="panel-body">
                        <p class="card-text"><input type="checkbox" runat="server" id="support" checked="checked" /> Included in the Proposal</p> 
                        <p class="card-text"><input type="checkbox" runat="server" id="hostedFireWallSupport" /> Include Hosted Firewall Support</p> 
                        <button id="Button6" type="button" class="btn btn-sm btn-default pull-right" runat="server" data-toggle="modal" data-target="#popForSupport" style="margin-top:28px;">
                            Add Content
                        </button>
                       <div class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" id="popForSupport" >
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Sales Proposal Reference Content</h4>
                                    </div>
                                     <div class="modal-body">
                                         <select class="form-control" name="sup_ref" id="sup_ref" onchange="SelectRef()" runat="server" style="text-align:center; margin-top:10px;margin-bottom:10px;">
                                          <option value="3Ref" selected="selected">Include 3 Reference</option>
                                          <option value="5Ref">Include 5 Reference</option>
                                        </select>
                                             <table class="table table-striped" id="Ref">
                                            <thead id="tblHead">
                                              <tr>
                                                <th class="text-center">References</th>
                                                <th class="text-center">Name</th>
                                                <th class="text-center">Phone</th>
                                                <th class="text-center">Email</th>
                                                <th class="text-center">Service Provided</th>
                                              </tr>
                                            </thead>
                                            <tbody>
                                              <tr><td><input type="text" name="businessNameA" class="form-control" runat="server" id="businessNameA" placeholder="Business Name A" /></td>
                                                <td><input type="text" name="contactNameA" class="form-control" runat="server" id="contactNameA" placeholder="Contact Name A" /></td>
                                                <td><input type="text" name="contactPhoneA" class="form-control" runat="server" id="contactPhoneA" placeholder="Contact Phone A" /></td>
                                                <td><input type="text" name="contactEmailA" class="form-control" runat="server" id="contactEmailA" placeholder="Contact Email A" /></td>
                                                <td class="text-right"><textarea class="form-control" runat="server" maxlength="265" id="serviceProvided_A" style="min-width: 100%;" rows="6" placeholder="Insert Content for Service Provided A"></textarea></td>
                                              </tr>
                                              <tr><td><input type="text" name="BusinessNameB" class="form-control" runat="server" id="businessNameB" placeholder="Business Name B" /></td>
                                                <td><input type="text" name="contactNameB" class="form-control" runat="server" id="contactNameB" placeholder="Contact Name B" /></td>
                                                <td><input type="text" name="contactPhoneB" class="form-control" runat="server" id="contactPhoneB" placeholder="Contact Phone B" /></td>
                                                <td><input type="text" name="contactEmailB" class="form-control" runat="server" id="contactEmailB" placeholder="Contact Email B" /></td>
                                                <td class="text-right"><textarea class="form-control" runat="server" maxlength="265" id="serviceProvided_B" style="min-width: 100%;" rows="6" placeholder="Insert Content for Service Provided B"></textarea></td>
                                              </tr>
                                              <tr><td><input type="text" class="form-control" name="BusinessNameC" runat="server" id="businessNameC" placeholder="Business Name C" /></td>
                                                <td><input type="text" class="form-control" name="contactNameC" runat="server" id="contactNameC" placeholder="Contact Name C" /></td>
                                                  <td><input type="text" name="contactPhoneC" class="form-control" runat="server" id="contactPhoneC" placeholder="Contact Phone C" /></td>
                                                <td><input type="text" name="contactEmailC" class="form-control" runat="server" id="contactEmailC" placeholder="Contact Email C" /></td>
                                                <td class="text-right"><textarea class="form-control" runat="server" maxlength="265" id="serviceProvided_C" style="min-width: 100%;" rows="6" placeholder="Insert Content for Service Provided C"></textarea></td>
                                              </tr>
                                            </tbody>
                                          </table>
                                        <table class="table table-striped" id="LSR" style="display:none;">
                                            <thead id="Thead1">
                                              <tr>
                                                <th class="text-center">Large Scale References</th>
                                                <th class="text-center">Name</th>
                                                 <th class="text-center">Phone</th>
                                                <th class="text-center">Email</th>
                                                <th class="text-center">Service Provided</th>
                                              </tr>
                                            </thead>
                                            <tbody>
                                              <tr><td><input type="text" name="businessNameD" class="form-control" runat="server" id="businessNameD" placeholder="Business Name D" /></td>
                                                <td><input type="text" name="contactNameD" class="form-control" runat="server" id="contactNameD" placeholder="Contact Name D" /></td>
                                                <td><input type="text" name="contactPhoneD" class="form-control" runat="server" id="contactPhoneD" placeholder="Contact Phone D" /></td>
                                                <td><input type="text" name="contactEmailD" class="form-control" runat="server" id="contactEmailD" placeholder="Contact Email D" /></td>
                                                <td class="text-right"><textarea class="form-control" runat="server" maxlength="265" id="serviceProvided_D" style="min-width: 100%;" rows="6" placeholder="Insert Content for Service Provided D"></textarea></td>
                                              </tr>
                                              <tr><td><input type="text" name="businessNameE" class="form-control" runat="server" id="businessNameE" placeholder="Business Name E" /></td>
                                                <td><input type="text" name="contactNameE" class="form-control" runat="server" id="contactNameE" placeholder="contact Name E" /></td>
                                                <td><input type="text" name="contactPhoneE" class="form-control" runat="server" id="contactPhoneE" placeholder="Contact Phone E" /></td>
                                                <td><input type="text" name="contactEmailE" class="form-control" runat="server" id="contactEmailE" placeholder="Contact Email E" /></td>
                                                <td class="text-right"><textarea class="form-control" runat="server" maxlength="265" id="serviceProvided_E" style="min-width: 100%;" rows="6" placeholder="Insert Content for Service Provided E"></textarea></td>
                                              </tr>
                                            </tbody>
                                          </table>
                                    </div> 
                                    <div class="modal-footer">
                                        <button id="Button7" class="btn btn-primary" onclick="InsertSupport()"  runat="server" >Insert</button>
                                        <button class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>                      
                    </div>
                    </div>
                  </div>

               </div>  

                <div style="text-align:center">
                     <asp:Button ID="AddSelectedPages"  runat="server" OnCommand="AddPage" Style="margin-left:14px; border: 2px solid #e7e7e7; border-radius: 12px; background-color: white; font-size:x-large;" CommandArgument="1" Font-Bold="True" Height="120px" Width="500px" Text="Generate Proposal" />
                </div>
            <%--</div>--%>
        </div>
       </form>

        <div class="container" style="margin-top:25px; text-align:center; padding: 0 15px !important;">
                <div style="background-color:#001e42;">
                    <label style="padding-top:40px;padding-bottom:40px; font-size:120%; font-family:Roboto Regular; color:#fff;">Segra Proprietary: This information contained here in is for use by authorized only and is not for general distribution</label>
                </div>
            </div>        
         <script src ="main.js"></script>
</body>
</html>
