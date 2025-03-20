public class MetaAhorro
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal MontoObjetivo { get; set; }
    public decimal MontoAhorrado { get; set; }
    public DateTime FechaLimite { get; set; }

    public decimal Progreso => MontoObjetivo > 0 ? (MontoAhorrado / MontoObjetivo) * 100 : 0;
}
