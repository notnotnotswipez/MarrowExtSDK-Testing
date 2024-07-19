namespace SLZ.Marrow.Zones
{
    public interface IZonePrioritizable
    {
        public int Priority { get; }
    }

    public interface IZoneLinkable<in TZoneActivator>
        where TZoneActivator : class
    {
    }
}