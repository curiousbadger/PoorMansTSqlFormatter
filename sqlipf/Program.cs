using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlipf
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            Console.WriteLine("foo");
            bool allowParsingErrors = true;
            string inputSQL = "select foo from bar where car";
            //inputSQL = Clipboard.GetText();
            //Console.WriteLine("GetText:" + inputSQL);
            string afs=PoorMansTSqlFormatterLib.SqlFormattingManager.AutoFormat();
            Console.WriteLine(afs);
            Console.WriteLine("done!");

            return 0;
            //string formattedSQL = ((new PoorMansTSqlFormatterLib.SqlFormattingManager())).Format(inputSQL);
            //Console.WriteLine(formattedSQL);
            return 0;
            var options = new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatterOptions
            {
                KeywordStandardization = true,
                IndentString = "\t",
                SpacesPerTab = 4,
                MaxLineWidth = 999,
                NewStatementLineBreaks = 2,
                NewClauseLineBreaks = 1,
                TrailingCommas = false,
                SpaceAfterExpandedComma = false,
                ExpandBetweenConditions = true,
                ExpandBooleanExpressions = true,
                ExpandCaseStatements = true,
                ExpandCommaLists = true,
                BreakJoinOnSections = false,
                UppercaseKeywords = true,
                ExpandInLists = true
            };

            var formatter = new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatter(options);
            //formatter.ErrorOutputPrefix = _generalResourceManager.GetString("ParseErrorWarningPrefix") + Environment.NewLine;
            var formattingManager = new PoorMansTSqlFormatterLib.SqlFormattingManager(formatter);
            
            if (!string.IsNullOrEmpty(inputSQL))
            {
                string formattedOutput = null;
                bool parsingError = false;
                Exception parseException = null;
                try
                {
                    formattedOutput = formattingManager.Format(inputSQL, ref parsingError);
                    Console.WriteLine(formattedOutput);
                    //hide any handled parsing issues if they were requested to be allowed
                    if (allowParsingErrors) parsingError = false;
                }
                catch (Exception ex)
                {
                    parseException = ex;
                    parsingError = true;
                }
            }

            return 0;
        }
    }
}
