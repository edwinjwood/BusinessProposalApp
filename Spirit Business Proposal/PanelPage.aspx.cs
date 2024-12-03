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
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Net;

namespace Spirit_Business_Proposal
{
    public partial class PanelPage : System.Web.UI.Page
    {   
        string PathofAllTheFiles = WebConfigurationManager.AppSettings["PathofAllTheFiles"];
        protected void Page_Load(object sender, EventArgs e)
        {
            String NewCompName = Request.QueryString["CompanyName123"];
            company_name.Text = NewCompName;
        }
        public void AddPage(object sender, EventArgs e)
        {
            // IF Result_exec file doesnot exist response.redirect it to front page it will avoid another exception               
           //Who we Are
            Boolean executive_summary = Executive_Summary.Checked;           
            Boolean objectives = Obectives.Checked;
            Boolean objectivesImg = ObjectivesImg.Checked;
            Boolean Solution = solution.Checked;
            Boolean Implementation = implementation.Checked;
            Boolean Support = support.Checked;
            String NewCompName = Request.QueryString["CompanyName123"];
            String randomnumber = Request.QueryString["randonMumber"];

 /* ----------------------------------------------- Insert the Content of Table of COntent in Here if it is Checked ------------- */

            if(tableContent.Checked)
            {
                String toc = PathofAllTheFiles + "SampleDoc/TableofContents.pdf";
                String file1 = PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf";
                String temp = PathofAllTheFiles + "OutputPdfToDownload/Result_toc" + NewCompName + randomnumber + ".pdf";
                String[] source_files = { file1, toc };
                String Output_ToC = mergePdf(source_files, temp);
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf");
                }
            }

/* ----------------------------------------------- Insert the Content of Executive Summary in Here if it is Checked --- */
  
            if(executive_summary == true){
                String listItem = InsertWhoWeAre(tableContent.Checked);
                String[] separators = {","};
                String[] files = listItem.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                String temp = PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf";
                String Output_Executive = mergePdf(files, temp);
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_toc" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_toc" + NewCompName + randomnumber + ".pdf");
                }
            }

            /* ------------------------------ Insert the Content of Testimonials in Here if it is Checked ------------------- */

            if(includePortfolio.Checked == true)
            {
                List<string> Portfolio = new List<string>();
                String file2 = PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf";
                Portfolio.Add(file2);
                if (BigRedBox.Checked)
                {
                    String file = PathofAllTheFiles + "SampleDoc/Testimonials/Big Red Box_CaseStudy_Template.pdf";
                    Portfolio.Add(file);
                }
                if (ColumbiaFireflies.Checked)
                {
                    String file = PathofAllTheFiles + "SampleDoc/Testimonials/ColumbiaFireflies_CaseStudy_Template.pdf";
                    Portfolio.Add(file);
                }
                if (CommWellHealth.Checked)
                {
                    String file = PathofAllTheFiles + "SampleDoc/Testimonials/CommWell_CaseStudy_Template.pdf";
                    Portfolio.Add(file);
                }
                if (IGSIndustries.Checked)
                {
                    String file = PathofAllTheFiles + "SampleDoc/Testimonials/IGSIndustries_CaseStudy_Template.pdf";
                    Portfolio.Add(file);
                }
                if (LoundonUnitedFC.Checked)
                {
                    String file = PathofAllTheFiles + "SampleDoc/Testimonials/LoudounUnited_CaseStudy_Template.pdf";
                    Portfolio.Add(file);
                }
                if (MembersCreditUnion.Checked)
                {
                    String file = PathofAllTheFiles + "SampleDoc/Testimonials/MembersCreditUnion_CaseStudy_Template.pdf";
                    Portfolio.Add(file);
                }
                if (PinnacleTrailers.Checked)
                {
                    String file = PathofAllTheFiles + "SampleDoc/Testimonials/PinnacleTrailers_CaseStudy_Template.pdf";
                    Portfolio.Add(file);
                }
                if (RadiologyAssociatesOfRichmond.Checked)
                {
                    String file = PathofAllTheFiles + "SampleDoc/Testimonials/Radiology_Assoc_CaseStudy_Template.pdf";
                    Portfolio.Add(file);
                }
                if (RossMouldLLC.Checked)
                {
                    String file = PathofAllTheFiles + "SampleDoc/Testimonials/RossMouldLLC_CaseStudy_Template.pdf";
                    Portfolio.Add(file);
                }
                String[] PortFolioAllFiles = Portfolio.ToArray();                
                String Output_Objective = mergePdf(PortFolioAllFiles, PathofAllTheFiles + "OutputPdfToDownload/Result_portfolio" + NewCompName + randomnumber + ".pdf");
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf");
                }
            }

            /* ----------------------------------------------- Insert the Content of Objectives in Here if it is Checked ----------------------------------- */

            if (objectives == true)
            {
                List<string> objective_form = new List<string>();                
                if (includePortfolio.Checked) {
                    String file2 = PathofAllTheFiles + "OutputPdfToDownload/Result_portfolio" + NewCompName + randomnumber + ".pdf";
                    objective_form.Add(file2);
                    if (includeCustomContent.Checked && CustomContentFileDictionary.ContainsKey(NewCompName+randomnumber))
                    {
                        List<string> CustomContentFileList = CustomContentFileDictionary[NewCompName + randomnumber];
                        for (int i = 0; i < CustomContentFileList.Count; i++)
                        {
                            objective_form.Add(CustomContentFileList[i]);
                        }
                    }
                }
                else
                {
                    String file2 = PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf";
                    objective_form.Add(file2);
                }
                Boolean includeCoverSolution = IncludeCoverSolution.Checked;
                if (includeCoverSolution == true)
                {
                    String SolutionCover = PathofAllTheFiles + "SampleDoc/3A_Solutions_Divider.pdf";
                    objective_form.Add(SolutionCover);
                }
                    String[] all_file = objective_form.ToArray();
                
                String Output_Objective = mergePdf(all_file, PathofAllTheFiles + "OutputPdfToDownload/Result_obj" + NewCompName + randomnumber + ".pdf");
                    if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf"))
                    {
                        File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf");
                    }
                    if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf"))
                    {
                        File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf");
                    }
                    if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_portfolio" + NewCompName + randomnumber + ".pdf"))
                    {
                        File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_portfolio" + NewCompName + randomnumber + ".pdf");
                    }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result2" + NewCompName + randomnumber + ".pdf"))
                    {
                        File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result2" + NewCompName + randomnumber + ".pdf");
                    }
                    if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result3" + NewCompName + randomnumber + ".pdf"))
                    {
                        File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result3" + NewCompName + randomnumber + ".pdf");
                    }
                    if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result4" + NewCompName + randomnumber + ".pdf"))
                    {
                        File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result4" + NewCompName + randomnumber + ".pdf");
                    }
                if (CustomContentFileDictionary.ContainsKey(NewCompName + randomnumber))
                {
                    List<string> CustomContentFileList = CustomContentFileDictionary[NewCompName + randomnumber];
                    for (int i = 0; i < CustomContentFileList.Count; i++)
                    {
                        if (File.Exists(CustomContentFileList[i]))
                        {
                            File.Delete(CustomContentFileList[i]);
                        }
                    }
                    CustomContentFileList.Clear();
                    CustomContentFileDictionary.Remove(NewCompName + randomnumber);
                }
            }
            if(objectives == false)
            {
                List<string> objective_form = new List<string>();
                if (includePortfolio.Checked)
                {
                    String file2 = PathofAllTheFiles + "OutputPdfToDownload/Result_portfolio" + NewCompName + randomnumber + ".pdf";
                    objective_form.Add(file2);
                }
                else
                {
                    String file2 = PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf";
                    objective_form.Add(file2);
                }
                String[] all_file = objective_form.ToArray();
                String Output_Objective = mergePdf(all_file, PathofAllTheFiles + "OutputPdfToDownload/Result_obj" + NewCompName + randomnumber + ".pdf");
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_Exec" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_portfolio" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_portfolio" + NewCompName + randomnumber + ".pdf");
                }
            }
            
 /* ----------------------------------------------- Insert the Content of Solution in Here if it is Checked ----------------------------------- */

            if(Solution == true)
            {
                String listItemSol = InsertSolution();
                String[] separators = { "," };
                String[] files = listItemSol.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                String temp = PathofAllTheFiles + "OutputPdfToDownload/Result_Sol" + NewCompName + randomnumber + ".pdf";
                String Output_Solution = mergePdf(files, temp);
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_obj" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_obj" + NewCompName + randomnumber + ".pdf");
                }
            }
             
/* ----------------------------------------------- Insert the Content of Implementaion in Here if it is Checked ------------------------------ */

            if (Implementation == true)
            {
                String listItemImp = InsertImplementation();
                String[] separators = { "," };
                String[] files = listItemImp.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                String temp = PathofAllTheFiles + "OutputPdfToDownload/Result_Imp" + NewCompName + randomnumber + ".pdf";
                String Output_Solution = mergePdf(files, temp);
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_Imp" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_Imp" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_Sol" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_Sol" + NewCompName + randomnumber + ".pdf");
                }
            }

            /* ----------------------------------------------- Insert the Content of Objectives Image in Here if it is Checked ------------ */
            if (objectivesImg == true)
            {
                String Image_Insert = InsertTheObjImg(); 
                String[] separators = { "@#$" };
                String[] forms = Image_Insert.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                String Img_page = form_Img.Value.ToString();
                String file1 = PathofAllTheFiles + "OutputPdfToDownload/Result_Imp" + NewCompName + randomnumber + ".pdf";
                String result1 = PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf";
                String result2 = PathofAllTheFiles + "OutputPdfToDownload/Result2" + NewCompName + randomnumber + ".pdf";
                String result3 = PathofAllTheFiles + "OutputPdfToDownload/Result3" + NewCompName + randomnumber + ".pdf";
                String result4 = PathofAllTheFiles + "OutputPdfToDownload/Result4" + NewCompName + randomnumber + ".pdf";
                String result5 = PathofAllTheFiles + "OutputPdfToDownload/Result5" + NewCompName + randomnumber + ".pdf";
                List<string> objective_Img = new List<string>();
                objective_Img.Add(file1);
                if (Img_page == "1")
                {
                    String ObjectivesandOpportunitiesImagepg1 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg2.pdf";
                    PdfReader reader_Img = new PdfReader(ObjectivesandOpportunitiesImagepg1);
                    //PdfStamper object to modify the content to the PDF
                    using (FileStream outFile_Img = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img = new PdfStamper(reader_Img, outFile_Img);
                        AcroFields form = stamp_Img.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 2 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName+randomnumber) && ImagesToUploadDictionary[NewCompName+randomnumber].Count > 0)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[0], "Page 2 Image");
                        }                            
                        form.SetField("Image Page 2 Title", forms[0]);
                        stamp_Img.Dispose();
                        reader_Img.Dispose();
                        outFile_Img.Dispose();
                    }
                    objective_Img.Add(result1);
                }
                else if (Img_page == "2")
                {
                    String ObjectivesandOpportunitiesImagepg1 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg2.pdf";
                    PdfReader reader_Img = new PdfReader(ObjectivesandOpportunitiesImagepg1);
                    //PdfStamper object to modify the content to the PDF
                    using (FileStream outFile_Img = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img = new PdfStamper(reader_Img, outFile_Img);
                        //get form fields
                        AcroFields form = stamp_Img.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 2 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 0)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[0], "Page 2 Image");
                        }
                        form.SetField("Image Page 2 Title", forms[0]);
                        stamp_Img.Dispose();
                        reader_Img.Dispose();
                        outFile_Img.Dispose();
                    }

                    String ObjectivesandOpportunitiesImagepg2 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg3.pdf";
                    PdfReader reader_Img2 = new PdfReader(ObjectivesandOpportunitiesImagepg2);
                    //PdfStamper object to modify the content to the PDF
                    using (FileStream outFile_Img2 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result2" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img2 = new PdfStamper(reader_Img2, outFile_Img2);
                        //get form fields
                        AcroFields form = stamp_Img2.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 3 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 1)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[1], "Page 3 Image");
                        }
                        form.SetField("Image Page 3 Title", forms[1]);
                        stamp_Img2.Dispose();
                        reader_Img2.Dispose();
                        outFile_Img2.Dispose();
                    }
                    objective_Img.Add(result1);
                    objective_Img.Add(result2);
                }
                else if (Img_page == "3")
                {
                    String ObjectivesandOpportunitiesImagepg1 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg2.pdf";
                    PdfReader reader_Img = new PdfReader(ObjectivesandOpportunitiesImagepg1);
                    using (FileStream outFile_Img = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img = new PdfStamper(reader_Img, outFile_Img);
                        AcroFields form = stamp_Img.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 2 Image");
                        if (ad != null &&  ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 0)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[0], "Page 2 Image");
                        }
                        form.SetField("Image Page 2 Title", forms[0]);
                        stamp_Img.Dispose();
                        reader_Img.Dispose();
                        outFile_Img.Dispose();
                    }
                    String ObjectivesandOpportunitiesImagepg2 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg3.pdf";
                    PdfReader reader_Img2 = new PdfReader(ObjectivesandOpportunitiesImagepg2);
                    using (FileStream outFile_Img2 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result2" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img2 = new PdfStamper(reader_Img2, outFile_Img2);
                        AcroFields form = stamp_Img2.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 3 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 1)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[1], "Page 3 Image");
                        }
                        form.SetField("Image Page 3 Title", forms[1]);
                        stamp_Img2.Dispose();
                        reader_Img2.Dispose();
                        outFile_Img2.Dispose();
                    }
                    String ObjectivesandOpportunitiesImagepg3 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg4.pdf";
                    PdfReader reader_Img3 = new PdfReader(ObjectivesandOpportunitiesImagepg3);
                    using (FileStream outFile_Img3 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result3" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img3 = new PdfStamper(reader_Img3, outFile_Img3);
                        AcroFields form = stamp_Img3.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 4 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 2)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[2], "Page 4 Image");
                        }
                        form.SetField("Image Page 4 Title", forms[2]);
                        stamp_Img3.Dispose();
                        reader_Img3.Dispose();
                        outFile_Img3.Dispose();
                    }
                    objective_Img.Add(result1);
                    objective_Img.Add(result2);
                    objective_Img.Add(result3);
                }
                else if (Img_page == "4")
                {
                    String ObjectivesandOpportunitiesImagepg1 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg2.pdf";
                    PdfReader reader_Img = new PdfReader(ObjectivesandOpportunitiesImagepg1);
                    using (FileStream outFile_Img = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img = new PdfStamper(reader_Img, outFile_Img);
                        AcroFields form = stamp_Img.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 2 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 0)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[0], "Page 2 Image");
                        }
                        form.SetField("Image Page 2 Title", forms[0]);
                        stamp_Img.Dispose();
                        reader_Img.Dispose();
                        outFile_Img.Dispose();
                    }
                    String ObjectivesandOpportunitiesImagepg2 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg3.pdf";
                    PdfReader reader_Img2 = new PdfReader(ObjectivesandOpportunitiesImagepg2);
                    using (FileStream outFile_Img2 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result2" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img2 = new PdfStamper(reader_Img2, outFile_Img2);
                        AcroFields form = stamp_Img2.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 3 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 1)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[1], "Page 3 Image");
                        }
                        form.SetField("Image Page 3 Title", forms[1]);
                        stamp_Img2.Dispose();
                        reader_Img2.Dispose();
                        outFile_Img2.Dispose();
                    }
                    String ObjectivesandOpportunitiesImagepg3 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg4.pdf";
                    PdfReader reader_Img3 = new PdfReader(ObjectivesandOpportunitiesImagepg3);
                    using (FileStream outFile_Img3 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result3" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img3 = new PdfStamper(reader_Img3, outFile_Img3);
                        AcroFields form = stamp_Img3.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 4 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 2)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[2], "Page 4 Image");
                        }
                        form.SetField("Image Page 4 Title", forms[2]);
                        stamp_Img3.Dispose();
                        reader_Img3.Dispose();
                        outFile_Img3.Dispose();
                    }
                    String ObjectivesandOpportunitiesImagepg4 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg5.pdf";
                    PdfReader reader_Img4 = new PdfReader(ObjectivesandOpportunitiesImagepg4);
                    using (FileStream outFile_Img4 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result4" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img4 = new PdfStamper(reader_Img4, outFile_Img4);
                        AcroFields form = stamp_Img4.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 5 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 3)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[3], "Page 5 Image");
                        }
                        form.SetField("Image Page 5 Title", forms[3]);
                        stamp_Img4.Dispose();
                        reader_Img4.Dispose();
                        outFile_Img4.Dispose();
                    }
                    objective_Img.Add(result1);
                    objective_Img.Add(result2);
                    objective_Img.Add(result3);
                    objective_Img.Add(result4);
                }
                else if (Img_page == "5")
                {
                    String ObjectivesandOpportunitiesImagepg1 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg2.pdf";
                    PdfReader reader_Img = new PdfReader(ObjectivesandOpportunitiesImagepg1);
                    using (FileStream outFile_Img = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img = new PdfStamper(reader_Img, outFile_Img);
                        AcroFields form = stamp_Img.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 2 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 0)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[0], "Page 2 Image");
                        }
                        form.SetField("Image Page 2 Title", forms[0]);
                        stamp_Img.Dispose();
                        reader_Img.Dispose();
                        outFile_Img.Dispose();
                    }
                    String ObjectivesandOpportunitiesImagepg2 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg3.pdf";
                    PdfReader reader_Img2 = new PdfReader(ObjectivesandOpportunitiesImagepg2);
                    using (FileStream outFile_Img2 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result2" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img2 = new PdfStamper(reader_Img2, outFile_Img2);
                        AcroFields form = stamp_Img2.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 3 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 1)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[1], "Page 3 Image");
                        }
                        form.SetField("Image Page 3 Title", forms[1]);
                        stamp_Img2.Dispose();
                        reader_Img2.Dispose();
                        outFile_Img2.Dispose();
                    }
                    String ObjectivesandOpportunitiesImagepg3 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg4.pdf";
                    PdfReader reader_Img3 = new PdfReader(ObjectivesandOpportunitiesImagepg3);
                    using (FileStream outFile_Img3 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result3" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img3 = new PdfStamper(reader_Img3, outFile_Img3);
                        AcroFields form = stamp_Img3.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 4 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 2)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[2], "Page 4 Image");
                        }
                        form.SetField("Image Page 4 Title", forms[2]);
                        stamp_Img3.Dispose();
                        reader_Img3.Dispose();
                        outFile_Img3.Dispose();
                    }
                    String ObjectivesandOpportunitiesImagepg4 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg5.pdf";
                    PdfReader reader_Img4 = new PdfReader(ObjectivesandOpportunitiesImagepg4);
                    using (FileStream outFile_Img4 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result4" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img4 = new PdfStamper(reader_Img4, outFile_Img4);
                        AcroFields form = stamp_Img4.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 5 Image");
                        if (ad != null &&  ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 3)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[3], "Page 5 Image");
                        }
                        form.SetField("Image Page 5 Title", forms[3]);
                        stamp_Img4.Dispose();
                        reader_Img4.Dispose();
                        outFile_Img4.Dispose();
                    }
                    String ObjectivesandOpportunitiesImagepg5 = PathofAllTheFiles + "SampleDoc/Objectives/ImplementationImagepg6.pdf";

                    PdfReader reader_Img5 = new PdfReader(ObjectivesandOpportunitiesImagepg5);
                    
                    using (FileStream outFile_Img5 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Result5" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp_Img5 = new PdfStamper(reader_Img5, outFile_Img5);
                        AcroFields form = stamp_Img5.AcroFields;
                        PushbuttonField ad = form.GetNewPushbuttonFromField("Page 6 Image");
                        if (ad != null && ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber) && ImagesToUploadDictionary[NewCompName + randomnumber].Count > 4)
                        {
                            List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                            addImageToPdf(form, ad, listOfImagesToUpload[4], "Page 6 Image");
                        }
                        form.SetField("Image Page 6 Title", forms[4]);
                        stamp_Img5.Dispose();
                        reader_Img5.Dispose();
                        outFile_Img5.Dispose();
                    }
                    objective_Img.Add(result1);
                    objective_Img.Add(result2);
                    objective_Img.Add(result3);
                    objective_Img.Add(result4);
                    objective_Img.Add(result5);
                }

                String[] all_file = objective_Img.ToArray();
                String Output_Objective_Image = mergePdf(all_file, PathofAllTheFiles + "OutputPdfToDownload/Result_obj_Img" + NewCompName + randomnumber + ".pdf");
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result2" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result2" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result3" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result3" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result4" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result4" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result5" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result5" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_Imp" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_Imp" + NewCompName + randomnumber + ".pdf");
                }
                if(ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber))
                {
                    List<string> listOfImagesToUpload = ImagesToUploadDictionary[NewCompName + randomnumber];
                    for (int i = 0; i < listOfImagesToUpload.Count; i++)
                    {
                        if (File.Exists(listOfImagesToUpload[i]))
                        {
                            File.Delete(listOfImagesToUpload[i]);
                        }
                        listOfImagesToUpload.Clear();
                        ImagesToUploadDictionary.Remove(NewCompName + randomnumber);
                    }
                }
               
            }
            if (objectivesImg == false)
            {
                String file1 = PathofAllTheFiles + "OutputPdfToDownload/Result_Imp" + NewCompName + randomnumber + ".pdf";
                List<string> objective_Img = new List<string>();
                objective_Img.Add(file1);
                String[] all_file = objective_Img.ToArray();
                String Output_Objective_Image = mergePdf(all_file, PathofAllTheFiles + "OutputPdfToDownload/Result_obj_Img" + NewCompName + randomnumber + ".pdf");
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_Imp" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_Imp" + NewCompName + randomnumber + ".pdf");
                }
            }

            /* ----------------------------------------------- Insert the Proposal Cover in Here if it is Checked ------------------------- */

            if (proposal.Checked == true)
            {
                List<String> filesProposal = new List<string>(); 
                filesProposal.Add(PathofAllTheFiles + "OutputPdfToDownload/Result_obj_Img" + NewCompName + randomnumber + ".pdf");
                if (IncludeProposalCover.Checked == true) {
                    String file2 = PathofAllTheFiles + "SampleDoc/5A_Proposal_Divider.pdf";
                    filesProposal.Add(file2);
                }
                if (IncludeProposalDoc.Checked == true  && ProposalFileDictionary.ContainsKey(NewCompName+randomnumber) ) {
                    List<string> ProposalFileList = ProposalFileDictionary[NewCompName + randomnumber];
                    for (int i = 0; i < ProposalFileList.Count; i++) {
                        filesProposal.Add(ProposalFileList[i]);
                    }
                }
                String[] fileProposalArray = filesProposal.ToArray();
                String Output_Proposal = mergePdf(fileProposalArray, PathofAllTheFiles + "OutputPdfToDownload/Result_proposal" + NewCompName + randomnumber + ".pdf");
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_obj_Img" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_obj_Img" + NewCompName + randomnumber + ".pdf");
                }
                if (ProposalFileDictionary.ContainsKey(NewCompName + randomnumber)) {
                    List<string> ProposalFileList = ProposalFileDictionary[NewCompName + randomnumber];
                    for (int i = 0; i < ProposalFileList.Count; i++)
                    {
                        if (File.Exists(ProposalFileList[i]))
                        {
                            File.Delete(ProposalFileList[i]);
                        }
                    }
                    ProposalFileList.Clear();
                    ProposalFileDictionary.Remove(NewCompName + randomnumber);
                }
            }
            else {
                String file1 = PathofAllTheFiles + "OutputPdfToDownload/Result_obj_Img" + NewCompName + randomnumber + ".pdf";
                List<string> filesProposal = new List<string>();
                filesProposal.Add(file1);
                String[] all_file = filesProposal.ToArray();
                String Output_Proposal = mergePdf(all_file, PathofAllTheFiles + "OutputPdfToDownload/Result_proposal" + NewCompName + randomnumber + ".pdf");
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_obj_Img" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_obj_Img" + NewCompName + randomnumber + ".pdf");
                }
            }

            /* ----------------------------------------------- Insert the Content of Support in Here if it is Checked ---------------------------- */

            if (Support == true || Support == false)
            {
                String listItemSup = InsertSupport(Support);
                String[] separators = { "," };
                String[] files = listItemSup.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                String temp2 = PathofAllTheFiles + "OutputPdfToDownload/Result_Sup" + NewCompName + randomnumber + ".pdf";
                //String[] Source_File = { temp, toc };
                String Done = PathofAllTheFiles + "OutputPdfToDownload/" + NewCompName + randomnumber + "SpiritBusinessProposal.pdf";
                String Output_Toc = mergePdf(files, Done);
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_toc" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_toc" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_Sup" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_Sup" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Result_proposal" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Result_proposal" + NewCompName + randomnumber + ".pdf");
                }
                if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_Sup" + NewCompName + randomnumber + ".pdf"))
                {
                    File.Delete(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_Sup" + NewCompName + randomnumber + ".pdf");
                }
            }

/* ----------------------------------------------- Insert the Content of Table of COntent in Here if it is Checked  */

            Response.Write("<script> alert('File Created' )</script>");
            Response.Redirect("download.aspx?CompName12345=" + NewCompName + "&randmValue=" + randomnumber, false);
        }
/* ----------------------------------------------- Merge PDF Files ----------------------------------- */


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

        public void addImageToPdf(AcroFields form, PushbuttonField ad, String ImagePath, String FieldName)
        {            
                String imageURL = ImagePath;
                ad.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                ad.ProportionalIcon = true;
                ad.Image = iTextSharp.text.Image.GetInstance((imageURL));
                form.ReplacePushbuttonField(FieldName, ad.Field);            
        }

/* ----------------------------------------------- Insert the Content of WhoWeAre Page PopUP ----------------------------------- */
        public String InsertWhoWeAre(Boolean toc) {
            String NewCompName = Request.QueryString["CompanyName123"];
            String randomnumber = Request.QueryString["randonMumber"];
            List<string> whoweareList = new List<string>();
            String file1 = toc ? PathofAllTheFiles + "OutputPdfToDownload/Result_toc" + NewCompName + randomnumber + ".pdf" : PathofAllTheFiles + "OutputPdfToDownload/Result" + NewCompName + randomnumber + ".pdf";
            whoweareList.Add(file1);
            if (IncludeCoverWhoWeAre.Checked){
                whoweareList.Add(PathofAllTheFiles + "SampleDoc/2A_Why_Segra_Divider" + ".pdf");
            }
            
            whoweareList.Add(PathofAllTheFiles + "SampleDoc/Overview/1_WelcometoSegra.pdf");
            whoweareList.Add(PathofAllTheFiles + "SampleDoc/Overview/2_ArticlesofExcellence.pdf");
            whoweareList.Add(PathofAllTheFiles + "SampleDoc/Overview/3_RedifiningDelivery.pdf");
            if(CSC_KPIWhySegra.Checked)
            {
                String CSC_KPIWhySegraFile = PathofAllTheFiles + "SampleDoc/Overview/CSC_KPIWhySegra.pdf";
                whoweareList.Add(CSC_KPIWhySegraFile);
            }
            if (CSRWhySegra.Checked)
                whoweareList.Add(PathofAllTheFiles + "SampleDoc/Overview/CSRWhySegra.pdf");
            if (InTheCommunitySC.Checked){
                String file4 = PathofAllTheFiles + "SampleDoc/Overview/InTheCommunitySC.pdf";
                whoweareList.Add(file4);
            }
            if (InTheCommunityNC.Checked)
            {
                String file4 = PathofAllTheFiles + "SampleDoc/Overview/InTheCommunityNC.pdf";
                whoweareList.Add(file4);
            }
            if (InTheCommunityMD.Checked ){
                String file4 = PathofAllTheFiles + "SampleDoc/Overview/OurCommitmentToMaryland.pdf";
                whoweareList.Add(file4);
            }
            if (InTheCommunityPA.Checked){
                String file4 = PathofAllTheFiles + "SampleDoc/Overview/OurCommitmentToPennsylvania.pdf";
                whoweareList.Add(file4);
            }
            if (InTheCommunityVA.Checked){
                String file4 = PathofAllTheFiles + "SampleDoc/Overview/OurCommitmentToVirginia.pdf";
                whoweareList.Add(file4);
            }
            if (InTheCommunityWV.Checked){
                String file4 = PathofAllTheFiles + "SampleDoc/Overview/OurCommitmentToWestVirginia.pdf";
                whoweareList.Add(file4);
            }
            return String.Join(", ", whoweareList);
        }

/* ----------------------------------------------- Insert the Content of Objective Image Page PopUP ----------------------------------- */
        
        public String InsertTheObjImg()
        { 
            List<string> all_img_title = new List<string>();
            all_img_title.Add(img1.Value.ToString());
            all_img_title.Add(img2.Value.ToString());
            all_img_title.Add(img3.Value.ToString());
            all_img_title.Add(img4.Value.ToString());
            all_img_title.Add(img5.Value.ToString());
            return String.Join("@#$ ", all_img_title);
        }
        
/* ----------------------------------------------- Insert the Content of Solution Page PopUP ----------------------------------- */

        public String InsertSolution() 
        {
            String NewCompName = Request.QueryString["CompanyName123"];
            String randomnumber = Request.QueryString["randonMumber"];
            List<string> Solution = new List<string>();
            String file1 = PathofAllTheFiles + "OutputPdfToDownload/Result_obj" + NewCompName + randomnumber + ".pdf";
            Solution.Add(file1);
            if (algoLoudSpeakerPaging.Checked) 
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/AlgoLoudSpeakerPaging.pdf");
            if (baas.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/BaaS.pdf");
            if (colocation.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/Colocation.pdf");
            if (contactCenter.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/ContactCenter.pdf");
            if (convergedVoice.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/ConvergedVoice.pdf");
            if (ddosEdgeProtect.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/DDoSEdgeProtect.pdf");
            if (dedicatedInternetAccess.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/DedicatedInternetAccess.pdf");
            if (dRaaS.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/DRaaS.pdf");
            if (ethernetService.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/EthernetService.pdf");
            if (expressCloudAccess.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/ExpressCloudAccess.pdf");
            if (extensiveFiberNetwork.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/ExtensiveFiberNetwork.pdf");
            if (hostedFirewall.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/HostedFirewall.pdf");
            if (hostedHdVoice.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/HostedHDVoice.pdf");
            if (iaas.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/IaaS.pdf");
            if (ipFax.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/IPFax.pdf");
            if (lTeSecureAccess.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/LTESecureAccess.pdf");
            if (lTESecureBackup.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/LTESecureBackup.pdf");
            if (managedRouter.Checked )
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/ManagedRouter.pdf");
            if (managedSwitch.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/ManagedSwitch.pdf");
            if (managedWifi.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/ManagedWiFi.pdf");
            if (mobileVoice.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/MobileVoice.pdf");
            if (mpls.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/MPLS.pdf");
            if (musicOnHold.Checked )
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/MusicOnHold.pdf");
            if (onDemandConferencing.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/OnDemandConferencing.pdf");
            if (privateLine.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/PrivateLine.pdf");
            if (remoteOfficeLAN.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/Remote Office LAN.pdf");
            if (sdwan.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/SDWAN.pdf");
            if (segraHealthCareNetwork.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/SegraHealthcareNetwork.pdf");
            if (sipFlex.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/SIPFlex.pdf");
            if (sOCaaS.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/SOCaaS.pdf");
            if(unify.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/Unify.pdf");
            if (vPRN.Checked)
                Solution.Add(PathofAllTheFiles + "SampleDoc/Solution/VPRN.pdf");
            return String.Join(", ", Solution);
        }

/* ----------------------------------------------- Insert the Content of Implementation Page PopUP ----------------------------------- */

        public String InsertImplementation()
        {
            List<string> Implementation = new List<string>();
            String NewCompName = Request.QueryString["CompanyName123"];
            String randomnumber = Request.QueryString["randonMumber"];
            Implementation.Add(PathofAllTheFiles + "OutputPdfToDownload/Result_sol" + NewCompName + randomnumber + ".pdf");
            Boolean includeImplementationCover = IncludeImplementationCover.Checked;
            if (includeImplementationCover == true) {
                String fileCover = PathofAllTheFiles + "SampleDoc/4A_Implementation_Divider.pdf";
                Implementation.Add(fileCover);
            }
            String file2 = PathofAllTheFiles + "SampleDoc/Implementation/SalesProposalGuideToSuccessfulImplementation.pdf";
            Implementation.Add(file2);
            String file3 = PathofAllTheFiles + "SampleDoc/Implementation/SalesProposalImplementationSpecifics.pdf";
            Implementation.Add(file3);
            String SalesProposalImplementationSpecifics2Form = PathofAllTheFiles + "SampleDoc/Implementation/SalesProposalImplementationSpecifics2Formv2.pdf";
            PdfReader reader = new PdfReader(SalesProposalImplementationSpecifics2Form);
            using (FileStream outFile = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_Imp" + NewCompName + randomnumber + ".pdf", FileMode.Create))
            {
                PdfStamper stamp = new PdfStamper(reader, outFile);
                AcroFields form = stamp.AcroFields;
                form.SetField("Account Executive Name", accountExecutiveName1.Text);
                form.SetField("Title AE", titleAE1.Text);
                form.SetField("AE Phone Number", AEContactNumber.Value.ToString());
                form.SetField("AE Email Address", AEEmail.Value.ToString());
                form.SetField("Sales Engineer/TC Name", salesEng1.Text);
                form.SetField("Title SE", titleSE.Value.ToString());
                form.SetField("SE Phone Number", SENumber.Value.ToString());
                form.SetField("SE Email Address", SEEmail.Value.ToString());
                form.SetField("Sales Support Specialist", salseSupportSpecialistName1.Text);
                form.SetField("Title SSS", titleSalseSupportSpecialist.Value.ToString());
                form.SetField("SSS Phone Number", SSENumber.Value.ToString());
                form.SetField("SSS Email Address", SSEEmail.Value.ToString());
                form.SetField("Regional Sales Director Name", regionalSalseManagerName1.Text);
                form.SetField("Title RSD", titleRegionalSalseManager.Value.ToString());
                form.SetField("RSD Phone Number", RSMENumber.Value.ToString());
                form.SetField("RSD Email Address", RSMEEmail.Value.ToString());
                form.SetField("VP of Sales Name", directorSalseName1.Text);
                form.SetField("Title VP", titleDirectorSalse.Value.ToString());
                form.SetField("VP Phone Number", DSNumber.Value.ToString());
                form.SetField("VP Email Address", DSEmail.Value.ToString());
                form.SetField("Chief Marketing Officer", chiefMarketingOfficer1.Text);
                form.SetField("Title CMO", titleChiefMarketingOfficer.Value.ToString());
                form.SetField("CMO Phone Number", CMONumber.Value.ToString());
                form.SetField("CMO Email Address", CMOEmail.Value.ToString());
                stamp.Dispose();
                reader.Dispose();
                outFile.Dispose();
            }
            Implementation.Add(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_Imp" + NewCompName + randomnumber + ".pdf");
            return String.Join(", ", Implementation);
        }


        public static IDictionary<string, List<string>> ProposalFileDictionary = new Dictionary<string, List<string>>();
        protected void UploadFile(object sender, EventArgs e)
        {
            String NewCompName = Request.QueryString["CompanyName123"];
            String randomnumber = Request.QueryString["randonMumber"];
            if (ProposalFileDictionary.ContainsKey(NewCompName + randomnumber))
            {
                List<string> ProposalFileList;
                ProposalFileDictionary.TryGetValue(NewCompName + randomnumber, out ProposalFileList);
                if (ProposalFileList.Count < 3)
                {
                    ProposalFileList = buildListOfFiles(NewCompName, randomnumber, ProposalFileList);
                    ProposalFileDictionary[NewCompName + randomnumber] = ProposalFileList;
                    //String script = "window.onload = function() { UploadFilePop1($('#popForProposal').modal('show')) };";
                    //ClientScript.RegisterStartupScript(this.GetType(), "UploadFilePop1", script, true);
                    showIncludeProp.Style.Add(HtmlTextWriterStyle.Display, "none");
                    Label2.Text = ProposalFileList.Count + " File Uploaded ";
                    Label2.Attributes.Add("style", "color:Green !important;");
                    IncludeProposalDoc.Checked = true;
                    IncludeProposalDoc.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                else
                {
                    Label2.Text = "Max 3 Files Uploaded";
                    Label2.Attributes.Add("style", "color:Red !important;");
                }
            }
            else
            {
                List<string> ProposalFileList = new List<string>();
                ProposalFileList = buildListOfFiles(NewCompName, randomnumber, ProposalFileList);
                ProposalFileDictionary.Add(NewCompName + randomnumber, ProposalFileList);
                showIncludeProp.Style.Add(HtmlTextWriterStyle.Display, "none");
                Label2.Text = ProposalFileList.Count + " File Uploaded ";
                Label2.Attributes.Add("style", "color:Green !important;");
                IncludeProposalDoc.Checked = true;
                IncludeProposalDoc.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            
        }

        public List<string> buildListOfFiles(String NewCompName, String randomnumber, List<string> ProposalFileList)
        {
            if (ProposalFileList.Count < 3 && PricingUpload1.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in PricingUpload1.PostedFiles)
                {
                    PricingUpload1.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Proposal/" + "QuoteBuilderProposal 1" + NewCompName + randomnumber + ".pdf"));
                    ProposalFileList.Add(PathofAllTheFiles + "SampleDoc/Proposal/" + "QuoteBuilderProposal 1" + NewCompName + randomnumber + ".pdf");
                    listOfUploadedFiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            if (ProposalFileList.Count < 3 && PricingUpload2.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in PricingUpload2.PostedFiles)
                {
                    PricingUpload2.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Proposal/" + "QuoteBuilderProposal 2" + NewCompName + randomnumber + ".pdf"));
                    ProposalFileList.Add(PathofAllTheFiles + "SampleDoc/Proposal/" + "QuoteBuilderProposal 2" + NewCompName + randomnumber + ".pdf");
                    listOfUploadedFiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            if (ProposalFileList.Count < 3 && PricingUpload3.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in PricingUpload3.PostedFiles)
                {
                    PricingUpload3.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Proposal/" + "QuoteBuilderProposal 3" + NewCompName + randomnumber + ".pdf"));
                    ProposalFileList.Add(PathofAllTheFiles + "SampleDoc/Proposal/" + "QuoteBuilderProposal 3" + NewCompName + randomnumber + ".pdf");
                    listOfUploadedFiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            return ProposalFileList;
        }

        //public Panel createPanel(string Proposalfilename)
        //{
        //    Panel panel = new Panel();
        //    //panel.ID = Proposalfilename + ProposalFileList.Count;
        //    //panel.Controls.Add(deleteFileButton(Proposalfilename, Proposalfilename + ProposalFileList.Count));
        //    return panel;
        //}

        //public LinkButton deleteFileButton(string fileName, string fileId)
        //{
        //    LinkButton lnkLike = new LinkButton();
        //    lnkLike.ID = fileId;
        //    lnkLike.Text = " " +fileName;
        //    lnkLike.CausesValidation = false;
        //    lnkLike.CssClass = "btn btn-danger glyphicon glyphicon-remove-circle";
        //    lnkLike.Click += new EventHandler(removeFile);
        //    return lnkLike; 
        //}

        //public void removeFile(object sender, EventArgs e)
        //{
        //    //Debug.WriteLine("Wher a,ad idsf iidf isdf isdf ds");
        //    //LinkButton button = (LinkButton)sender;
        //    //string buttonId = button.ID;
        //    //if (proposalListPanel.Controls.Contains(button)) 
        //    //{
        //    //    proposalListPanel.Controls.Remove(button);
        //    //}
        //}


        public static IDictionary<string, List<string>> CustomContentFileDictionary = new Dictionary<string, List<string>>();
        //public static List<String> CustomContentFileList = new List<string>();
        protected void UploadCustomContentFile(object sender, EventArgs e) {
            String NewCompName = Request.QueryString["CompanyName123"];
            String randomnumber = Request.QueryString["randonMumber"];
            if (CustomContentFileDictionary.ContainsKey(NewCompName + randomnumber)) {
                List<string> CustomContentFileList;
                CustomContentFileDictionary.TryGetValue(NewCompName + randomnumber, out CustomContentFileList);
                if (CustomContentFileList.Count < 3)
                {
                    CustomContentFileList = buildListForCustomeContent(NewCompName, randomnumber, CustomContentFileList);
                    CustomContentFileDictionary[NewCompName + randomnumber] = CustomContentFileList;
                    //String script = "window.onload = function() { UploadFilePop2($('#popForObjective').modal('show')) };";
                    //ClientScript.RegisterStartupScript(this.GetType(), "UploadFilePop2", script, true);
                    showIncludeProp.Style.Add(HtmlTextWriterStyle.Display, "none");
                    LabelObjective.Text = CustomContentFileList.Count + " File Uploaded ";
                    LabelObjective.Attributes.Add("style", "color:Green !important;");
                    includeCustomContent.Checked = true;
                    includeCustomContent.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                else
                {
                    //listofCustomContentFile.Text = "";
                    LabelObjective.Text = "Max 3 Files Uploaded";
                    LabelObjective.Attributes.Add("style", "color:Red !important;");
                }
            }
            else
            {
                List<string> CustomContentFileList = new List<string>();
                CustomContentFileList = buildListForCustomeContent(NewCompName, randomnumber, CustomContentFileList);
                CustomContentFileDictionary.Add(NewCompName + randomnumber, CustomContentFileList);
                showIncludeProp.Style.Add(HtmlTextWriterStyle.Display, "none");
                LabelObjective.Text = CustomContentFileList.Count + " File Uploaded ";
                LabelObjective.Attributes.Add("style", "color:Green !important;");
                includeCustomContent.Checked = true;
                includeCustomContent.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        public List<string> buildListForCustomeContent(String NewCompName, String randomnumber, List<string> CustomContentFileList)
        {
            if (CustomContentFileList.Count < 3 && FileUploadCustomContent1.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in FileUploadCustomContent1.PostedFiles)
                {
                    FileUploadCustomContent1.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Objectives/" + "CustomContentFile 1" + NewCompName + randomnumber + ".pdf"));
                    CustomContentFileList.Add(PathofAllTheFiles + "SampleDoc/Objectives/" + "CustomContentFile 1" + NewCompName + randomnumber + ".pdf");
                    listofCustomContentFile.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            if (CustomContentFileList.Count < 3 && FileUploadCustomContent2.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in FileUploadCustomContent2.PostedFiles)
                {
                    FileUploadCustomContent2.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Objectives/" + "CustomContentFile 2" + NewCompName + randomnumber + ".pdf"));
                    CustomContentFileList.Add(PathofAllTheFiles + "SampleDoc/Objectives/" + "CustomContentFile 2" + NewCompName + randomnumber + ".pdf");
                    listofCustomContentFile.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            if (CustomContentFileList.Count < 3 && FileUploadCustomContent3.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in FileUploadCustomContent3.PostedFiles)
                {
                    FileUploadCustomContent3.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Objectives/" + "CustomContentFile 3" + NewCompName + randomnumber + ".pdf"));
                    CustomContentFileList.Add(PathofAllTheFiles + "SampleDoc/Objectives/" + "CustomContentFile 3" + NewCompName + randomnumber + ".pdf");
                    listofCustomContentFile.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            return CustomContentFileList;
        }

        public static IDictionary<string, List<string>>ImagesToUploadDictionary = new Dictionary<string, List<string>>();
        //public static List<String> listOfImagesToUpload = new List<string>();
        protected void UploadImagePage1(object sender, EventArgs e)
        {
            String NewCompName = Request.QueryString["CompanyName123"];
            String randomnumber = Request.QueryString["randonMumber"];
            if (ImagesToUploadDictionary.ContainsKey(NewCompName + randomnumber))
            {
                List<string> listOfImagesToUpload;
                ImagesToUploadDictionary.TryGetValue(NewCompName + randomnumber, out listOfImagesToUpload);
                if (listOfImagesToUpload.Count < 5) {
                    listOfImagesToUpload = buildListOfImage(NewCompName, randomnumber, listOfImagesToUpload);
                    ImagesToUploadDictionary[NewCompName + randomnumber] = listOfImagesToUpload;
                    Label1.Text = listOfImagesToUpload.Count + " Images Uploaded ";
                    Label1.Attributes.Add("style", "color:Green !important;");
                }
                else
                {                    
                    Label1.Text = "Max 5 Images Uploaded";
                    Label1.Attributes.Add("style", "color:Red !important;");
                }
            }
            else
            {
                List<string> listOfImagesToUpload = new List<string>();
                listOfImagesToUpload = buildListOfImage(NewCompName, randomnumber, listOfImagesToUpload);
                ImagesToUploadDictionary.Add(NewCompName + randomnumber, listOfImagesToUpload);
                Label1.Text = listOfImagesToUpload.Count + " Images Uploaded ";
                Label1.Attributes.Add("style", "color:Green !important;");
            }            
        }        

        public List<string> buildListOfImage(string NewCompName, string randomnumber, List<string> listOfImagesToUpload)
        {
            if (ImageUploadPage1.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in ImageUploadPage1.PostedFiles)
                {
                    ImageUploadPage1.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 1" + NewCompName + randomnumber + ".jpg"));
                    listOfImagesToUpload.Add(PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 1" + NewCompName + randomnumber + ".jpg");
                    ListOfImagesToUpload.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            if (ImageUploadPage2.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in ImageUploadPage2.PostedFiles)
                {
                    ImageUploadPage2.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 2" + NewCompName + randomnumber + ".jpg"));
                    listOfImagesToUpload.Add(PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 2" + NewCompName + randomnumber + ".jpg");
                    ListOfImagesToUpload.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            if (ImageUploadPage3.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in ImageUploadPage3.PostedFiles)
                {
                    ImageUploadPage3.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 3" + NewCompName + randomnumber + ".jpg"));
                    listOfImagesToUpload.Add(PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 3" + NewCompName + randomnumber + ".jpg");
                    ListOfImagesToUpload.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            if (ImageUploadPage4.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in ImageUploadPage4.PostedFiles)
                {
                    ImageUploadPage4.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 4" + NewCompName + randomnumber + ".jpg"));
                    listOfImagesToUpload.Add(PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 4" + NewCompName + randomnumber + ".jpg");
                    ListOfImagesToUpload.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            if (ImageUploadPage5.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in ImageUploadPage5.PostedFiles)
                {
                    ImageUploadPage5.PostedFile.SaveAs((PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 5" + NewCompName + randomnumber + ".jpg"));
                    listOfImagesToUpload.Add(PathofAllTheFiles + "SampleDoc/Implementation/" + "Image 5" + NewCompName + randomnumber + ".jpg");
                    ListOfImagesToUpload.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
            return listOfImagesToUpload;
        }


        /* ----------------------------------------------- Insert the Content of Support Page PopUP ----------------------------------- */

        public String InsertSupport(Boolean support)
        {
            List<string> Support = new List<string>();
            String NewCompName = Request.QueryString["CompanyName123"];
            String randomnumber = Request.QueryString["randonMumber"];
            Support.Add(PathofAllTheFiles + "OutputPdfToDownload/Result_proposal" + NewCompName + randomnumber + ".pdf");
            Support.Add(PathofAllTheFiles + "SampleDoc/Support/SalesProposalSupport1.pdf");
            Support.Add(PathofAllTheFiles + "SampleDoc/Support/SalesProposalSupport2.pdf");
            if (hostedFireWallSupport.Checked)
                Support.Add(PathofAllTheFiles + "SampleDoc/HostedFirewallSupport.pdf");
            if (support == true)
            {
                String SalesProposalReferences_3 = PathofAllTheFiles + "SampleDoc/Support/SalesProposalReferences_3.pdf";
                String SalesProposalReferences_3regular_2largescale = PathofAllTheFiles + "SampleDoc/Support/SalesProposalReferences_3regular_2largescale.pdf";
                String sup_page = sup_ref.Value.ToString();
                if (sup_page == "3Ref")
                {
                    PdfReader reader = new PdfReader(SalesProposalReferences_3);
                    using (FileStream outFile = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_Sup" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp = new PdfStamper(reader, outFile);
                        AcroFields form = stamp.AcroFields;
                        form.SetField("Business Name A", businessNameA.Value.ToString());
                        form.SetField("Contact A Name", contactNameA.Value.ToString());
                        form.SetField("Contact A Phone Number", contactPhoneA.Value.ToString());
                        form.SetField("Contact A Email Address", contactEmailA.Value.ToString());
                        form.SetField("Services Provided A", serviceProvided_A.Value.ToString());
                        form.SetField("Business Name B", businessNameB.Value.ToString());
                        form.SetField("Contact B Name", contactNameB.Value.ToString());
                        form.SetField("Contact B Phone Number", contactPhoneB.Value.ToString());
                        form.SetField("Contact B Email Address", contactEmailB.Value.ToString());
                        form.SetField("Services Provided B", serviceProvided_B.Value.ToString());
                        form.SetField("Business Name C", businessNameC.Value.ToString());
                        form.SetField("Contact C Name", contactNameC.Value.ToString());
                        form.SetField("Contact C Phone Number", contactPhoneC.Value.ToString());
                        form.SetField("Contact C Email Address", contactEmailC.Value.ToString());
                        form.SetField("Services Provided C", serviceProvided_C.Value.ToString());
                        stamp.Dispose();
                        reader.Dispose();
                        outFile.Dispose();
                    }
                }
                else
                {
                    PdfReader reader2 = new PdfReader(SalesProposalReferences_3regular_2largescale);
                    using (FileStream outFile2 = new FileStream(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_Sup" + NewCompName + randomnumber + ".pdf", FileMode.Create))
                    {
                        PdfStamper stamp2 = new PdfStamper(reader2, outFile2);
                        AcroFields form = stamp2.AcroFields;
                        form.SetField("Business Name A", businessNameA.Value.ToString());
                        form.SetField("Contact A Name", contactNameA.Value.ToString());
                        form.SetField("Contact A Phone Number", contactPhoneA.Value.ToString());
                        form.SetField("Contact A Email Address", contactEmailA.Value.ToString());
                        form.SetField("Services Provided A", serviceProvided_A.Value.ToString());
                        form.SetField("Business Name B", businessNameB.Value.ToString());
                        form.SetField("Contact B Name", contactNameB.Value.ToString());
                        form.SetField("Contact B Phone Number", contactPhoneB.Value.ToString());
                        form.SetField("Contact B Email Address", contactEmailB.Value.ToString());
                        form.SetField("Services Provided B", serviceProvided_B.Value.ToString());
                        form.SetField("Business Name C", businessNameC.Value.ToString());
                        form.SetField("Contact C Name", contactNameC.Value.ToString());
                        form.SetField("Contact C Phone Number", contactPhoneC.Value.ToString());
                        form.SetField("Contact C Email Address", contactEmailC.Value.ToString());
                        form.SetField("Services Provided C", serviceProvided_C.Value.ToString());
                        form.SetField("Business Name D", businessNameD.Value.ToString());
                        form.SetField("Contact D Name", contactNameD.Value.ToString());
                        form.SetField("Contact D Phone Number", contactPhoneD.Value.ToString());
                        form.SetField("Contact D Email Address", contactEmailD.Value.ToString());
                        form.SetField("Services Provided D", serviceProvided_D.Value.ToString());
                        form.SetField("Business Name E", businessNameE.Value.ToString());
                        form.SetField("Contact E Name", contactNameE.Value.ToString());
                        form.SetField("Contact E Phone Number", contactPhoneE.Value.ToString());
                        form.SetField("Contact E Email Address", contactEmailE.Value.ToString());
                        form.SetField("Services Provided E", serviceProvided_E.Value.ToString());
                        stamp2.Dispose();
                        reader2.Dispose();
                        outFile2.Dispose();
                    }
                }
                Support.Add(PathofAllTheFiles + "OutputPdfToDownload/Temp_Result_Sup" + NewCompName + randomnumber + ".pdf");                
            }
            Support.Add(PathofAllTheFiles + "SampleDoc/Back_Cover.pdf");
            return String.Join(", ", Support);
        }

        protected void accountExecutiveName1_TextChanged(object sender, EventArgs e)
        {
            var accountname1 = accountExecutiveName1.Text;
            String[] name = accountname1.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var accountname = name[1] + ", " + name[0];
            List<String> userInfo = searchUserInDirectory(accountname);
            AEContactNumber.Value = userInfo[0];
            AEEmail.Value = userInfo[1];
            titleAE1.Text = userInfo[2];
        }

        protected void salesEng1_TextChanged(object sender, EventArgs e)
        {
            var salesname1 = salesEng1.Text;
            String[] name = salesname1.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var salesname = name[1] + ", " + name[0];
            List<String> userInfo = searchUserInDirectory(salesname);
            SENumber.Value = userInfo[0];
            SEEmail.Value = userInfo[1];
            titleSE.Value = userInfo[2];
        }

        protected void salseSupportSpecialistName1_TextChanged(object sender, EventArgs e)
        {
            var salesSSNname1 = salseSupportSpecialistName1.Text;
            String[] name = salesSSNname1.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var salesSSNname = name[1] + ", " + name[0];
            List<String> userInfo = searchUserInDirectory(salesSSNname);
            SSENumber.Value = userInfo[0];
            SSEEmail.Value = userInfo[1];
            titleSalseSupportSpecialist.Value = userInfo[2];
        }

        protected void regionalSalseManagerName1_TextChanged(object sender, EventArgs e)
        {
            var RegionalSalseManagerName11 = regionalSalseManagerName1.Text;
            String[] name = RegionalSalseManagerName11.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var RegionalSalseManagerName1 = name[1] + ", " + name[0];
            List<String> userInfo = searchUserInDirectory(RegionalSalseManagerName1);
            RSMENumber.Value = userInfo[0];
            RSMEEmail.Value = userInfo[1];
            titleRegionalSalseManager.Value = userInfo[2];
        }

        protected void directorSalseName1_TextChanged(object sender, EventArgs e)
        {
            var DirectorSalseName11 = directorSalseName1.Text;
            String[] name = DirectorSalseName11.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var DirectorSalseName1 = name[1] + ", " + name[0];
            List<String> userInfo = searchUserInDirectory(DirectorSalseName1);
            DSNumber.Value = userInfo[0];
            DSEmail.Value = userInfo[1];
            titleDirectorSalse.Value = userInfo[2];
        }

        protected void chiefMarketingOfficer1_TextChanged(object sender, EventArgs e)
        {
            var ChiefMarketingOfficer11 = chiefMarketingOfficer1.Text;
            String[] name = ChiefMarketingOfficer11.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var ChiefMarketingOfficer1 = name[1] + ", " + name[0];
            List<String> userInfo = searchUserInDirectory(ChiefMarketingOfficer1);
            CMONumber.Value = userInfo[0];
            CMOEmail.Value = userInfo[1];
            titleChiefMarketingOfficer.Value = userInfo[2];
        }
        
        private List<String> searchUserInDirectory(String userName)
        {
            List<String> userInfo = new List<string>();
            String number = "";
            String email = "";
            String title = "";
            try
            {
                DirectorySearcher dirSearcher = new DirectorySearcher();
                DirectoryEntry entry = new DirectoryEntry(dirSearcher.SearchRoot.Path);
                dirSearcher.Filter = "(&(objectClass=user)(objectcategory=person)(Name=" + userName + "*))";
                SearchResult srDisplayName = dirSearcher.FindOne();
                try
                {
                    number = srDisplayName.GetDirectoryEntry().Properties["TelephoneNumber"][0].ToString();
                }
                catch (Exception ex)
                {
                }
                try
                {
                    email = srDisplayName.GetDirectoryEntry().Properties["Mail"][0].ToString();
                }
                catch (Exception ex)
                {
                }
                try
                {
                    title = srDisplayName.GetDirectoryEntry().Properties["Title"][0].ToString();
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("LDAP Exception: " + ex.Message);
            }
            userInfo.Add(number);
            userInfo.Add(email);
            userInfo.Add(title);
            return userInfo;
        }       
    }
}