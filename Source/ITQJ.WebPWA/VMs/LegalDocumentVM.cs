namespace ITQJ.WebPWA.VMs
{
    public class LegalDocumentVM
    {
        public string Number { get; set; }

        public byte[] Image { get; set; }

        public int DocumentTypeId { get; set; }

        public DocumentTypeVM DocumentType { get; set; }

    }
}
