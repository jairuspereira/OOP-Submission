public class FastEnemy : BaseEnemy
{
    protected override void Start()
    {
        speed = 6f;
        maxHits = 1;
        base.Start();
    }
}
