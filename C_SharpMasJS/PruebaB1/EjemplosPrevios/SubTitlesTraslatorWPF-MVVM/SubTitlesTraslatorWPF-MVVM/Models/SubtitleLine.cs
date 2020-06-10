using System;
using System.Collections.Generic;
using System.Text;

namespace SubTitlesTraslatorWPF_MVVM.Models
{

    public enum TipeOfFile
    {
        vtt,
        srt
    }
    public class SubtitleLine
    {
        public int LineNumber { get; set; }
        public string Period { get; set; }
        public string Text { get; set; }
        //private List<string> LineasText { get; set; } //Ya veremos si las usamos después

        public static List<SubtitleLine> GetFromTextLines(List<string> lines, string extension)
        {
            var output = new List<SubtitleLine>();
            if (Enum.TryParse(extension, out TipeOfFile extFile))
            {
                switch (extFile)
                {
                    case TipeOfFile.srt:
                        output = lineasDeSrt(lines, extension);
                        break;
                    case TipeOfFile.vtt:
                    //TODO: implementar
                    //break;
                    default:
                        throw new ArgumentNullException($"Todavía no hemos implementado la importación para los ficheros de extensión :{extension}");
                        break;
                }
                return output;
            }
            else
            {
                throw new ArgumentNullException($"No hemos encontrado una definición para este formato, la importación para los ficheros de extensión :{extension}");
            }
        }


        private static List<SubtitleLine> lineasDeSrt(List<string> lines, string extension)
        {
            var output = new List<SubtitleLine>();

            for (var i = 0; i < lines.Count - 3; i++)
            {
                List<string> textos = new List<string>();
                int siguienteLinea = 2;

                if (int.TryParse(lines[i], out int lineNumber))
                {

                    bool numero = false;
                    do
                    {
                        textos.Add(lines[i + siguienteLinea]);
                        siguienteLinea++;
                        numero = int.TryParse(lines[i + siguienteLinea], out var nada);
                    } while (!numero && (i + siguienteLinea + 1) < lines.Count);


                }
                else
                {
                    throw new ArgumentNullException($"revisar el fichero y si es correcto habla con el desarrollador, línea:{lines[i]}");
                }
                var subtitleLine = new SubtitleLine()
                {
                    LineNumber = lineNumber,
                    Period = lines[i + 1],
                    Text = ConcatenarLineasText(textos)
                };
                output.Add(subtitleLine);
                i += textos.Count + 1;
            }
            return output;
        }
        private static string ConcatenarLineasText(List<string> lineas)
        {
            foreach (string item in lineas)
            {
                item.Trim();
            }
            return String.Join(' ', lineas);
        }
    }
}
 

