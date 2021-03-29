using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSerializeDeserialize
{
    public static class SoapNamespaces
    {
        public const string ENV = "http://schemas.xmlsoap.org/soap/envelope/";
        public const string URN = "urn:Ariba:Sourcing:vrealm_2992";
    }
    
    [XmlRoot(ElementName = "Envelope", Namespace = SoapNamespaces.ENV, IsNullable = false)]
    public partial class SourcingProjectRequestEnvelope
    {
        private SourcingProjectRequestEnvelopeHeader headerField;
        private SourcingProjectRequestEnvelopeBody bodyField;

        public SourcingProjectRequestEnvelope()
        {
            Header = new SourcingProjectRequestEnvelopeHeader();
            Body = new SourcingProjectRequestEnvelopeBody();
        }

        static SourcingProjectRequestEnvelope()
        {
            staticxmlns = new XmlSerializerNamespaces();
            staticxmlns.Add("urn", SoapNamespaces.URN);
            staticxmlns.Add("soapenv", SoapNamespaces.ENV);
        }

        [XmlElement(ElementName = "Header", Namespace = SoapNamespaces.ENV)]
        public SourcingProjectRequestEnvelopeHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        [XmlElement(ElementName = "Body", Namespace = SoapNamespaces.ENV)]
        public SourcingProjectRequestEnvelopeBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }

        private static XmlSerializerNamespaces staticxmlns;

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns { get { return staticxmlns; } set { } }
    }

    [XmlRoot(ElementName = "Header", Namespace = SoapNamespaces.ENV)]
    public partial class SourcingProjectRequestEnvelopeHeader
    {
        private SourcingProjectRequestHeaders headersField;

        public SourcingProjectRequestEnvelopeHeader()
        {
            Headers = new SourcingProjectRequestHeaders();
        }

        static SourcingProjectRequestEnvelopeHeader()
        {
            staticxmlns = new XmlSerializerNamespaces();
            staticxmlns.Add("urn", SoapNamespaces.URN);
        }

        private static XmlSerializerNamespaces staticxmlns;

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns { get { return staticxmlns; } set { } }

        [XmlElement(ElementName = "Headers", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public SourcingProjectRequestHeaders Headers
        {
            get
            {
                return this.headersField;
            }
            set
            {
                this.headersField = value;
            }
        }
    }

    [XmlRoot(ElementName = "Headers", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectRequestHeaders
    {
        private string variantField;
        private string partitionField;

        [XmlElement(ElementName = "variant", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public string variant
        {
            get
            {
                return this.variantField;
            }
            set
            {
                this.variantField = value;
            }
        }

        [XmlElement(ElementName = "partition", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public string partition
        {
            get
            {
                return this.partitionField;
            }
            set
            {
                this.partitionField = value;
            }
        }

        static SourcingProjectRequestHeaders()
        {
            staticxmlns = new XmlSerializerNamespaces();
            staticxmlns.Add("urn", SoapNamespaces.URN);
        }

        private static XmlSerializerNamespaces staticxmlns;

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns { get { return staticxmlns; } set { } }
    }

    [XmlRoot(ElementName = "Body", Namespace = SoapNamespaces.ENV)]
    public partial class SourcingProjectRequestEnvelopeBody
    {
        private SourcingProjectImportRequest sourcingProjectImportRequestField;

        public SourcingProjectRequestEnvelopeBody()
        {
            SourcingProjectImportRequest = new SourcingProjectImportRequest();
        }

        [XmlElement(ElementName = "SourcingProjectImportRequest", Namespace = "urn:Ariba:Sourcing:vrealm_2992", IsNullable = false)]
        public SourcingProjectImportRequest SourcingProjectImportRequest
        {
            get
            {
                return this.sourcingProjectImportRequestField;
            }
            set
            {
                this.sourcingProjectImportRequestField = value;
            }
        }
    }

    [XmlRoot(ElementName = "SourcingProjectImportRequest", Namespace = "urn:Ariba:Sourcing:vrealm_2992", IsNullable = false)]
    public partial class SourcingProjectImportRequest
    {
        private SourcingProjectImportRequestWSSourcingProjectInputBean_Item wSSourcingProjectInputBean_ItemField;
        private string partitionField;
        private string variantField;

        public SourcingProjectImportRequest()
        {
            WSSourcingProjectInputBean_Item = new SourcingProjectImportRequestWSSourcingProjectInputBean_Item();
        }

        [XmlElement(ElementName = "WSSourcingProjectInputBean_Item", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public SourcingProjectImportRequestWSSourcingProjectInputBean_Item WSSourcingProjectInputBean_Item
        {
            get
            {
                return this.wSSourcingProjectInputBean_ItemField;
            }
            set
            {
                this.wSSourcingProjectInputBean_ItemField = value;
            }
        }

        [XmlAttribute(AttributeName = "partition")]
        public string partition
        {
            get
            {
                return this.partitionField;
            }
            set
            {
                this.partitionField = value;
            }
        }

        [XmlAttribute(AttributeName = "variant")]
        public string variant
        {
            get
            {
                return this.variantField;
            }
            set
            {
                this.variantField = value;
            }
        }
    }

    [XmlRoot(ElementName = "WSSourcingProjectInputBean_Item", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_Item
    {
        private SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItem itemField;

        public SourcingProjectImportRequestWSSourcingProjectInputBean_Item()
        {
            itemField = new SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItem();
        }

        [XmlElement(ElementName = "item", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItem Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    [XmlType(AnonymousType = true, Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItem
    {
        private string actionField;
        private string onBehalfUserIdField;
        private string onBehalfUserPasswordAdapterField;
        private string parentWorkspaceIdField;
        private SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFields projectHeaderFieldsField;
        private string templateIdField;
        private string workspaceIdField;

        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItem()
        {
            projectHeaderFieldsField = new SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFields();
        }

        public string Action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }

        public string OnBehalfUserId
        {
            get
            {
                return this.onBehalfUserIdField;
            }
            set
            {
                this.onBehalfUserIdField = value;
            }
        }

        public string OnBehalfUserPasswordAdapter
        {
            get
            {
                return this.onBehalfUserPasswordAdapterField;
            }
            set
            {
                this.onBehalfUserPasswordAdapterField = value;
            }
        }

        public string ParentWorkspaceId
        {
            get
            {
                return this.parentWorkspaceIdField;
            }
            set
            {
                this.parentWorkspaceIdField = value;
            }
        }

        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFields ProjectHeaderFields
        {
            get
            {
                return this.projectHeaderFieldsField;
            }
            set
            {
                this.projectHeaderFieldsField = value;
            }
        }

        public string TemplateId
        {
            get
            {
                return this.templateIdField;
            }
            set
            {
                this.templateIdField = value;
            }
        }

        public string WorkspaceId
        {
            get
            {
                return this.workspaceIdField;
            }
            set
            {
                this.workspaceIdField = value;
            }
        }
    }

    [XmlRoot(ElementName = "ProjectHeaderFields", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFields
    {
        private SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCommodity commodityField;
        private SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCurrency currencyField;
        private SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsDescription descriptionField;
        private SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsRegion regionField;
        private SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsTitle titleField;

        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFields()
        {
            commodityField = new SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCommodity();
            currencyField = new SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCurrency();
            descriptionField = new SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsDescription();
            regionField = new SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsRegion();
            titleField = new SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsTitle();
        }

        [XmlElement(ElementName = "Commodity", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCommodity Commodity
        {
            get
            {
                return this.commodityField;
            }
            set
            {
                this.commodityField = value;
            }
        }

        [XmlElement(ElementName = "Currency", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCurrency Currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        [XmlElement(ElementName = "Description", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        [XmlElement(ElementName = "Region", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsRegion Region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        [XmlElement(ElementName = "Title", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsTitle Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    }

    [XmlRoot(ElementName = "Commodity", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCommodity
    {
        private SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCommodityItem itemField;

        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCommodity()
        {
            itemField = new SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCommodityItem();
        }

        [XmlElement(ElementName = "item", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCommodityItem Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    [XmlRoot(ElementName = "Currency", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCommodityItem
    {
        private string domainField;
        private byte uniqueNameField;

        [XmlElement(ElementName = "Domain", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public string Domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }

        [XmlElement(ElementName = "UniqueName", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public byte UniqueName
        {
            get
            {
                return this.uniqueNameField;
            }
            set
            {
                this.uniqueNameField = value;
            }
        }
    }

    [XmlType(AnonymousType = true, Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsCurrency
    {
        private string uniqueNameField;

        public string UniqueName
        {
            get
            {
                return this.uniqueNameField;
            }
            set
            {
                this.uniqueNameField = value;
            }
        }
    }

    [XmlRoot(ElementName = "Description", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsDescription
    {
        private string defaultStringTranslationField;

        [XmlElement(ElementName = "DefaultStringTranslation", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public string DefaultStringTranslation
        {
            get
            {
                return this.defaultStringTranslationField;
            }
            set
            {
                this.defaultStringTranslationField = value;
            }
        }
    }

    [XmlRoot(ElementName = "Region", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsRegion
    {
        private SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsRegionItem itemField;

        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsRegion()
        {
            itemField = new SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsRegionItem();
        }

        [XmlElement(ElementName = "item", Namespace = "urn:Ariba:Sourcing:vrealm_2992", IsNullable = false)]
        public SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsRegionItem item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    [XmlRoot(ElementName = "item", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsRegionItem
    {
        private string regionField;

        [XmlElement(ElementName = "Region", Namespace = "urn:Ariba:Sourcing:vrealm_2992", IsNullable = false)]
        public string Region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }
    }

    [XmlRoot(ElementName = "Title", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
    public partial class SourcingProjectImportRequestWSSourcingProjectInputBean_ItemItemProjectHeaderFieldsTitle
    {
        private string defaultStringTranslationField;

        [XmlElement(ElementName = "DefaultStringTranslation", Namespace = "urn:Ariba:Sourcing:vrealm_2992")]
        public string DefaultStringTranslation
        {
            get
            {
                return this.defaultStringTranslationField;
            }
            set
            {
                this.defaultStringTranslationField = value;
            }
        }
    }

    public class XmlSerialize
    {
        public string SerializeToString<T>(T obj)
        {
            var settings = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                Indent = false,
                NewLineHandling = NewLineHandling.None
            };

            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var xmlWriter = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(xmlWriter, obj);
                }

                stream.Position = 0;

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public XmlDocument SerializeToXmlDocument<T>(Type t, T o)
        {
            var result = new XmlDocument();
            var settings = new XmlWriterSettings { Indent = false };
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(t);

                using (var xmlWriter = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(xmlWriter, o);
                }

                stream.Position = 0;

                using (var reader = new StreamReader(stream))
                {
                    result.LoadXml(reader.ReadToEnd());
                }
            }

            return result;
        }

        public T DeSerialize<T>(string value)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(value))
                return (T)ser.Deserialize(sr);
        }
    }
}
