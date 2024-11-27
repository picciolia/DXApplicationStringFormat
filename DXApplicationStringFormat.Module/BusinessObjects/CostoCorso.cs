using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplicationStringFormat.Module.BusinessObjects;

[NavigationItem("Anagrafiche")]
[XafDisplayName("Costi corsi")]
[DefaultProperty("Descrizione")]
[ImageName("BO_Sale_Item")]
public class CostoCorso : BaseObject
{
    [ToolTip("Indicare per quale tipologia di corso di formazione verrà applicato il costo", "Tipologia corso")]
    public virtual TipoCorsoEnum TipoCorso { get; set; }

    [VisibleInListView(false)]
    [ToolTip("Indicare la durata massima in ore per il costo specificato")]
    public virtual int DurataFinoA { get; set; }

    [ToolTip("Indicare il costo (uscita) del corso di formazione a partecipante", "Costo corso di formazione")]
    public virtual decimal Costo { get; set; }

    public static string DescriptionFormat = "Costo corso {TipoCorso} fino a {DurataFinoA} ore";

    [NotMapped]
    [VisibleInDetailView(false)]
    public virtual string Descrizione
    {
        get
        {
            return ObjectFormatter.Format(DescriptionFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
        }
    }
}
