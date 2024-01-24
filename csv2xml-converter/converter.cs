using csv2xml_converter.Checksum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace csv2xml_converter
{
    public partial class converter : Form
    {
        public converter()
        {
            InitializeComponent();
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (Path.GetExtension(file).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    ConvertCsvToXml(file);
                }
                else
                {
                    MessageBox.Show($"Invalid file. Please drag or drop csv file!", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ConvertCsvToXml(string csvFilePath)
        {
            List<string> records = new List<string>();
            using (var reader = new StreamReader(csvFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var data = reader.ReadLine();

                    if (!string.IsNullOrWhiteSpace(data))
                    {
                        records.Add(data);
                    }
                }
            }
            string fileName = Path.GetFileNameWithoutExtension(csvFilePath).Replace(" ", "_");

            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclaration);

            XmlElement idListElement = xmlDoc.CreateElement("ID_List");
            xmlDoc.AppendChild(idListElement);

            idListElement.AppendChild(CreateElement(xmlDoc, "ListID", string.Empty));
            idListElement.AppendChild(CreateElement(xmlDoc, "ListName", fileName));
            idListElement.AppendChild(CreateElement(xmlDoc, "ListType", "Input"));
            idListElement.AppendChild(CreateElement(xmlDoc, "CreationDate", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt").ToUpper()));
           XmlElement positionsElement = xmlDoc.CreateElement("MainMenus");
            idListElement.AppendChild(positionsElement);

            string[] recordLimits = records.Take(25).ToArray();

            int totalPositions = 25;

            for (int i = 1; i <= totalPositions; i++)
            {
                XmlElement positionDataElement = xmlDoc.CreateElement("SubMenus");
                positionsElement.AppendChild(positionDataElement);

                int position = i + 1;

                positionDataElement.AppendChild(CreateElement(xmlDoc, "SubMenu", position.ToString()));

                string id1Value = (i - 1 < recordLimits.Length) ? recordLimits[i - 1] : GenerateBlankId(position);

          
                positionDataElement.AppendChild(CreateElement(xmlDoc, "ID_1", id1Value));
                positionDataElement.AppendChild(CreateElement(xmlDoc, "Name", "Emily"));


            }

            var rootElements = xmlDoc.GetElementsByTagName("ID_List");
            var attribute = xmlDoc.CreateAttribute("xmlns:i");
            attribute.Value = @"http://www.w3.org/2001/XMLSchema-instance";
            rootElements[0].Attributes.Append(attribute);


            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
               // saveFileDialog.InitialDirectory = @"C:\My Project\Entry List";

                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog.Title = "Save XML File";
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(csvFilePath) + ".xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = saveFileDialog.FileName;
                    xmlDoc.Save(xmlFilePath);
                    MessageBox.Show($"Converted XML file saved to: {xmlFilePath}", "Converted File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private XmlElement CreateElement(XmlDocument xmlDoc, string elementName, string elementValue)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = elementValue;
            return element;
        }

        private string GenerateBlankId(int position)
        {
            string timestamp = DateTime.Now.ToString("ddMMyyyy");
            return $"BLANK_{position}_{timestamp}";
        }
    }
}