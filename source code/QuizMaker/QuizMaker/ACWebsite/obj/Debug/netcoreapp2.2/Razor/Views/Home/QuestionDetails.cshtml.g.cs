#pragma checksum "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b6549dbf03031bf6b92719d794a617b69e9af11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_QuestionDetails), @"mvc.1.0.view", @"/Views/Home/QuestionDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/QuestionDetails.cshtml", typeof(AspNetCore.Views_Home_QuestionDetails))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\_ViewImports.cshtml"
using ACWebsite;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b6549dbf03031bf6b92719d794a617b69e9af11", @"/Views/Home/QuestionDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95e29ee725944b1385b3bd2b3cd7471a697206c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_QuestionDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ACWebsite.Models.Question>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Main", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
  
    ViewData["Title"] = "QuestionDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(128, 28, true);
            WriteLiteral("\n<h1>Question Details</h1>\n\n");
            EndContext();
            BeginContext(156, 160, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b6549dbf03031bf6b92719d794a617b69e9af114062", async() => {
                BeginContext(162, 147, true);
                WriteLiteral("\n    <style>\n        .correctColor:hover {\n            background-color: forestgreen;\n            transition: ease-in 0.5s;\n        }\n    </style>\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(316, 285, true);
            WriteLiteral(@"
<div>

    <hr />
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"" colspan=""4"">Question Details</th>
            </tr>
            <tr>
                <th class=""table-light text-dark"" style=""text-align: center; font-size: 20px"" colspan=""4"">");
            EndContext();
            BeginContext(602, 14, false);
#line 27 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
                                                                                                     Write(Model.question);

#line default
#line hidden
            EndContext();
            BeginContext(616, 57, true);
            WriteLiteral("</th>\n            </tr>\n        </thead>\n        <tbody>\n");
            EndContext();
#line 31 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
              
                Random rnd = new Random();
                List<string> answers;
                if (Model.answer_3 == null && Model.answer_4 == null)
                {
                    answers = new List<string>(new string[] { Model.answer_1.ToString(), Model.answer_2.ToString() });

                }
                else if (Model.answer_4 == null)
                {
                    answers = new List<string>(new string[] { Model.answer_1.ToString(), Model.answer_2.ToString(), Model.answer_3.ToString() });
                }
                else
                {
                    answers = new List<string>(new string[] { Model.answer_1.ToString(), Model.answer_2.ToString(), Model.answer_3.ToString(), Model.answer_4.ToString() });

                }


                int randomIndex = 0;

                String correctAnswer = answers[Model.answer - 1];
                List<string> shuffled = new List<string>();
                while (answers.Count > 0)
                {
                    randomIndex = rnd.Next(0, answers.Count); //Choose a random object in the list
                    shuffled.Add(answers[randomIndex]); //add it to the new, random list
                    answers.RemoveAt(randomIndex); //remove to avoid duplicates
                }




                

#line default
#line hidden
#line 64 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
                 for (int i = 0; i < shuffled.Count; i++)
                {

#line default
#line hidden
            BeginContext(2049, 25, true);
            WriteLiteral("                    <tr>\n");
            EndContext();
#line 67 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
                         if (shuffled[i] == correctAnswer)
                        {


#line default
#line hidden
            BeginContext(2160, 67, true);
            WriteLiteral("                            <td class=\" table-active correctColor\">");
            EndContext();
            BeginContext(2228, 11, false);
#line 70 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
                                                              Write(shuffled[i]);

#line default
#line hidden
            EndContext();
            BeginContext(2239, 6, true);
            WriteLiteral("</td>\n");
            EndContext();
#line 71 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
                            continue;

                        }
                        else
                        {


#line default
#line hidden
            BeginContext(2366, 53, true);
            WriteLiteral("                            <td class=\"table-active\">");
            EndContext();
            BeginContext(2420, 11, false);
#line 77 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
                                                Write(shuffled[i]);

#line default
#line hidden
            EndContext();
            BeginContext(2431, 6, true);
            WriteLiteral("</td>\n");
            EndContext();
#line 78 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
                        }

#line default
#line hidden
            BeginContext(2463, 26, true);
            WriteLiteral("                    </tr>\n");
            EndContext();
#line 80 "C:\Users\btrev\Desktop\Project Dropbox\Anti-Corruption source code\source code\QuizMaker\QuizMaker\ACWebsite\Views\Home\QuestionDetails.cshtml"
                }

#line default
#line hidden
            BeginContext(2522, 51, true);
            WriteLiteral("\n\n        </tbody>\n    </table>\n\n\n</div>\n<div>\n    ");
            EndContext();
            BeginContext(2573, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b6549dbf03031bf6b92719d794a617b69e9af1110616", async() => {
                BeginContext(2594, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2610, 8, true);
            WriteLiteral("\n</div>\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ACWebsite.Models.Question> Html { get; private set; }
    }
}
#pragma warning restore 1591
