using Fandul.Services.DepthChartProcessor.Domain;
using HtmlAgilityPack;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fandul.Services.DepthChartProcessor.Infrastructure.Utils
{
    public class DepthChartHtmlParser : IDepthChartHtmlParser
    {
        public DepthChartHtmlParser()
        {

        }

        public Dictionary<string, LinkedList<Player>> ParseHtml(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var tableRows = htmlDocument.DocumentNode.SelectNodes("//tbody/tr[td]");
            var depthChart = new Dictionary<string, LinkedList<Player>>();

            if (tableRows != null)
            {
                var practiceSqauds = 0;

                for (var x = 0; x < tableRows.Count; x++)
                {
                    var row = tableRows[x];

                    var columns = row.SelectNodes("td");
                    if (columns.Count > 1)
                    {
                        var playerLinkedList = new LinkedList<Player>();
                        var playerPosition = columns[0].InnerText.Trim();

                        for (int i = 1; i < columns.Count - 1; i += 2)
                        {
                            var num = columns[i].InnerText;
                            var name = columns[i + 1].InnerText;

                            if (!string.IsNullOrWhiteSpace(num) && !string.IsNullOrWhiteSpace(name))
                            {
                                var splitPlayerName = columns[i + 1].InnerText.Split(' ').ToList();
                                splitPlayerName.RemoveAt(2);
                                splitPlayerName[0] = splitPlayerName[0].Trim(',');

                                playerLinkedList.AddLast(new Player
                                {
                                    Number = int.Parse(num.Trim()),
                                    Name = string.Join(" ", splitPlayerName[1], splitPlayerName[0]),
                                    Position = playerPosition,
                                    PlayerCode = string.Join("", splitPlayerName[1], splitPlayerName[0])//Removing spaces from name as that will be th eplayer code which will be used in search
                                });
                            }
                        }

                        if (string.Equals(playerPosition, "PS"))
                        {
                            practiceSqauds++;
                            depthChart.Add(playerPosition + $"-{practiceSqauds}", playerLinkedList);
                        }
                        else
                        {
                            depthChart.Add(playerPosition, playerLinkedList);
                        }
                    }
                    else
                    {
                        x += 1;
                    }
                }
            }

            return depthChart;
        }
    }
}
