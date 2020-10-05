using System;
using System.Linq;

namespace AutoGenerateSqlConfigDataPoint
{
    public class DataPoint
    {
        public DataPoint()
        {
            TypeId = Guid.NewGuid();
            ConfigurationId = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DpType Type { get; set; }
        public Guid? ProductId { get; set; }
        private Guid? _definitionId;
        public Guid? DefinitionId
        {
            get
            {
                if (!_definitionId.HasValue && ProductId.HasValue)
                {
                    _definitionId = Guid.NewGuid();
                }
                return _definitionId;

            }
            set { _definitionId = value; }
        }

        public Guid TypeId { get; set; }
        public Guid ConfigurationId { get; set; }

        public Guid? CloneId { get; set; }
        public DataPoint[] Children { get; set; }

        public string ToConfig()
        {
            switch (Type)
            {
                case DpType.Structure:
                case DpType.Collection:
                case DpType.Table:
                case DpType.TableHeader:
                case DpType.TableBody:
                case DpType.TableFooter:
                case DpType.TableRow:
                    return $"N'{{\"Type\":{(int)Type},\"Children\":[{string.Join(",", Children.Select(x => $"\"{x.TypeId}\""))}]}}')";
                case DpType.Clone:
                    if (Name != "Comment")
                    {
                        return $"N'{{\"Type\":{(int)Type},\"Children\":[\"{CloneId}\"]}}')";
                    }
                    break;
            }
            return $"N'{{\"Type\":{(int)Type},\"Children\":[]}}')";
        }
    }
}
