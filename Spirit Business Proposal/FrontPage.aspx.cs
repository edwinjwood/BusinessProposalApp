using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Threading;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;




namespace Spirit_Business_Proposal
{
    
    public partial class FrontPage : System.Web.UI.Page
    {
      //  public static String CompanyName {get ;set;}
     //   String CompName;
        protected void Page_Load(object sender, EventArgs e)
        {
            // name.Value = System.Web.HttpContext.Current.User.Identity.Name;
            //  name.Value = System.Web.HttpContext.Current.User.Id;
            //try
            //{
            //    using (var context = new PrincipalContext(ContextType.Domain))
            //    {

            //        UserPrincipal principal = null;
            //        Debug.WriteLine(" User.Identity.Name = " + User.Identity.Name);
            //        if (User.Identity.Name != null)
            //        {
            //            using (principal = UserPrincipal.FindByIdentity(context, User.Identity.Name))
            //            {
            //                if (principal != null)
            //                {
            //                    var firstName = principal.GivenName;
            //                    var lastName = principal.Surname;
            //                    name.Value = firstName + " " + lastName;
            //                    var Phone = principal.VoiceTelephoneNumber.ToString();
            //                    phone.Value = Phone;
            //                    var Email = principal.EmailAddress;
            //                    exampleInputEmail1.Value = Email;
            //                    //Get User Title
            //                    String title;
            //                    DirectoryEntry directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;
            //                    if (directoryEntry.Properties.Contains("title"))
            //                    {
            //                        title = directoryEntry.Properties["title"].Value.ToString();
            //                        designation.Value = title;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //}
            try
            {
                string Name = User.Identity.Name;
                char[] delimiterChars = { '\\' };
                string[] words = Name.Split(delimiterChars);
                Debug.WriteLine(" User.Identity.Name = " + words[1]);
                        DirectorySearcher dirSearcher = new DirectorySearcher();
                        DirectoryEntry entry = new DirectoryEntry(dirSearcher.SearchRoot.Path);
                        dirSearcher.Filter = "(&(objectClass=user)(objectcategory=person)(sAMAccountName=" + words[1] + "*))";
                        SearchResult srDisplayName = dirSearcher.FindOne();
                        string firstName = "";
                        string lastName = "";
                        try
                        {
                            firstName = srDisplayName.GetDirectoryEntry().Properties["GivenName"][0].ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                        try
                        {
                            lastName = srDisplayName.GetDirectoryEntry().Properties["sn"][0].ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                        name.Value = firstName + " " + lastName;
                        try
                        {
                            designation.Value = srDisplayName.GetDirectoryEntry().Properties["Title"][0].ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                        try
                        {
                            phone.Value = srDisplayName.GetDirectoryEntry().Properties["TelephoneNumber"][0].ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                        try
                        {
                            exampleInputEmail1.Value = srDisplayName.GetDirectoryEntry().Properties["Mail"][0].ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                    
            }
            catch (Exception ex)
            {
                Debug.WriteLine("LDAP Exception: " + ex.Message);
            }
        }

        public void CreateFrontPage(object sender, CommandEventArgs e)
        {
            int startValue = -1000000;
            int endValue = 10000000;
            var random = new Random((int)DateTime.Now.Ticks);
            var randomValue = random.Next(startValue, endValue + 1);
            Debug.WriteLine("New Random Number  === " + randomValue);

            //    CompanyName = company_name.Value.ToString();
            String CompName2 = company_name.Value.ToString();

            Debug.WriteLine("Lets Chechk the Comapnay BName +++sddf+assdf+sdf+sf+sfd43253535345345345 " + CompName2);
            String test = String.Copy(CompName2);
            List<string> whoweareList = new List<string>();
            String[] splitCompName = /*Regex.Split(test.Trim(), @"\s*[.,;@#$%^&*!]\s*")*/ test.Split(new Char[] { ' ', ',', '.', ':', '\t', '@', '!', '#', '$', '%', '^', '&', '*', '(', ')', '{', '}', '|', '\\', '+', '=', '<', '>', '?', '/', '-', '_', ';', '~', '`'});
            foreach (string s in splitCompName)
            {
                if (s.Trim() != "")
                {
                    Debug.WriteLine(s);
                    whoweareList.Add(s);
                }
            }
            String NewCompanyNameRefined = String.Join(" ", whoweareList);
            Debug.WriteLine("Refined Company Name is =========================" + NewCompanyNameRefined);

            Debug.WriteLine("checkkkkkkkkkk = " + System.Text.RegularExpressions.Regex.IsMatch(CompName2, @"\s*[,;]\s*"));
           // var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            
                Debug.WriteLine("Company is correct no special  charachters/////");
                //  replace.InnerHtml = CompanyName;

            string PathofAllTheFiles = WebConfigurationManager.AppSettings["PathofAllTheFiles"];
            Debug.WriteLine("*************PfUSerName ====================== ************** =======" + PathofAllTheFiles);
            Debug.WriteLine("I am Here");
            String City;
            String Name2;
            String Designation;
            String Date;
            String number;
            String email;
            City = form_city.Value.ToString();
            Name2 = name.Value.ToString();
            var userName = Request["name"].ToString();
            var userDesignation = Request["designation"].ToString(); 
            var userPhone = Request["phone"].ToString();
            var userEmail = Request["exampleInputEmail1"].ToString();
            Designation = designation.Value.ToString();
            Date = date1.Value.ToString();
            number = phone.Value.ToString();
            email = exampleInputEmail1.Value.ToString();
            //path to Source File 
            Debug.WriteLine(userName + " sdssdsdsdada " + Name2 + " 888 8 88 88 8 8 8 8 8 8 8 8 8 8 8 8 8 8 " +  Designation);
            String source = "xyz";
            if (City == "ashvile")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/AshevilleCoverPageForm.pdf";
            }
            else if (City == "augusta")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/AugustaCoverPageForm.pdf";
            }
            else if (City == "charlsetonsc")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/CharlestonSCCoverPageForm.pdf";
            }
            else if (City == "charlsetonwv")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/CharlestonWVCoverPageForm.pdf";
            }
            else if (City == "columbia")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/ColumbiaCoverPageForm.pdf";
            }
            else if (City == "charlotte")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/CharlotteCoverPageForm.pdf";
            }
            else if (City == "charlottesville")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/CharlottesvilleCoverPageForm.pdf";
            }
            else if (City == "clarksburg")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/ClarksburgCoverPageForm.pdf";
            }
            else if (City == "durham")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/DurhamCoverPageForm.pdf";
            }
            else if (City == "frederick")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/FredrickCoverPageForm.pdf";
            }
            else if (City == "fayetteville") {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/FayettevilleCoverPageForm.pdf";
            }
            else if (City == "greensboro")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/GreensboroCoverPageForm.pdf";
            }
            else if (City == "greenvile")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/GreenvilleCoverPageForm.pdf";
            }
            else if (City == "hagerstown")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/HagerstownCoverPageForm.pdf";
            }
            else if (City == "harrisonburg")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/HarrisonburgCoverPageForm.pdf";
            }
            else if (City == "huntington")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/HuntingtonCoverPageForm.pdf";
            }
            else if (City == "leesburg")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/LeesburgCoverPageForm.pdf";
            }
            else if (City == "lynchburg")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/LynchburgCoverPageForm.pdf";
            }
            else if (City == "morgantown")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/MorgantownCoverPageForm.pdf";
            }
            else if (City == "norfolk")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/NorfolkCoverPageForm.pdf";
            }
            else if (City == "parkersburg")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/ParkersburgCoverPageForm.pdf";
            }
            else if (City == "pittsburg")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/PittsburgCoverPageForm.pdf";
            }
            else if (City == "raleigh")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/RaleighCoverPageForm.pdf";
            }
            else if (City == "richmond")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/RichmondCoverPageForm.pdf";
            }
            else if (City == "roanoke")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/RoanokeCoverPageForm.pdf";
            }
            else if (City == "virginiabeach")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/VirginiaBeachCoverPageForm.pdf";
            }
            else if (City == "waynesboro")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/WaynesboroCoverPageForm.pdf";
            }
            else if (City == "wilmington")
            {
                source = PathofAllTheFiles + "SampleDoc/Coverpage/WilmingtonCoverPageForm.pdf";
            }

            String CoverPageFile = PathofAllTheFiles + "SampleDoc/1A_Front_Cover.pdf";
            String RNumbr = randomValue.ToString();
            try
                {
                    using (PdfReader reader = new PdfReader(source))
                    {
                        

                        //PdfStamper object to modify the content ti the PDF
                        using (FileStream outFile = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result_t" + NewCompanyNameRefined + RNumbr + ".pdf", FileMode.Create))
                        { 
                            PdfStamper stamp = new PdfStamper(reader, outFile) /*{ FormFlattening = true}*/;
                            //get form fields 
                            AcroFields form = stamp.AcroFields;
                            //fill in text fields
                            form.SetField("Company Name", CompName2);
                            form.SetField("Date Goes Here", Date); 
                            form.SetField("Rep Name", userName); 
                            form.SetField("Title", userDesignation); 
                            form.SetField("Rep Phone Number", userPhone);
                            form.SetField("Rep Email Address", userEmail);
                            stamp.Dispose();
                            reader.Dispose();
                            outFile.Dispose();
                        
                        
                            // source.Close();
                        }
                    }
                }
                catch (System.IO.IOException ex)
                {
                    Debug.WriteLine("Exception" + ex);
                }
            String tempR = PathofAllTheFiles + "OutputPdfToDownload/Result_t" + NewCompanyNameRefined + RNumbr + ".pdf";
            String output = PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompanyNameRefined + RNumbr + ".pdf";
            String[] source_files = { CoverPageFile, tempR };
            String Output_ToC = mergePdf(source_files, output);

             
            if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_t" + NewCompanyNameRefined + RNumbr + ".pdf"))
            {
                File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_t" + NewCompanyNameRefined + RNumbr + ".pdf");
            }
            Response.Redirect("PanelPage.aspx?CompanyName123=" + NewCompanyNameRefined + "&randonMumber=" + randomValue, false);
        }

        public static String mergePdf(String[] source_files, String result)
        {

            //create Document object
            Document document = new Document();
            //create PdfCopy object
            using (PdfCopy copy = new PdfCopy(document, new FileStream(result, FileMode.Create)))
            {
                //open the document
                document.Open();
                //PdfReader variable
                PdfReader reader1;
                for (int i = 0; i < source_files.Length; i++)
                {
                    //create PdfReader object
                    reader1 = new PdfReader(source_files[i]);
                    //merge combine pages
                    for (int page = 1; page <= reader1.NumberOfPages; page++)
                        copy.AddPage(copy.GetImportedPage(reader1, page));
                    reader1.Dispose();
                }
                //Dispose the document object
                document.Dispose();
                copy.Dispose();
            }
            return result;
        }
        public char a { get; set; }
    }
}