using Application.Contracts;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common
{
    public class FileProcessor : IFileProcessor
    {
        public async Task<(string content, string customer)> ProcessFileAsync(IFormFile file, string customer)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            string content;

            if (file.FileName.EndsWith(".txt"))
            {
                content = await reader.ReadToEndAsync();
            }
            else if (file.FileName.EndsWith(".xml"))
            {
                var xdoc = XDocument.Parse(reader.ReadToEnd());
                content = xdoc.Root.Element("Content").Value;
                customer = xdoc.Root.Element("Customer").Value.Trim();
            }
            else
            {
                throw new NotSupportedException("unsupported file");
            }

            return (content, customer);
        }
    }
}