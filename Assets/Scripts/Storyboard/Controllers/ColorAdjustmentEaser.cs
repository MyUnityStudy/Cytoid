namespace Cytoid.Storyboard.Controllers
{
    public class ColorAdjustmentEaser : StoryboardRendererEaser<ControllerState>
    {
        public ColorAdjustmentEaser()
        {
            Provider.ColorAdjustment.Apply(it =>
            {
                it.enabled = false;
                it.Brightness = 1;
                it.Saturation = 1;
                it.Contrast = 1;
            });
        }

        public override void OnUpdate()
        {
            if (Config.UseEffects)
            {
                if (From.ColorAdjustment != null)
                {
                    Provider.ColorAdjustment.enabled = From.ColorAdjustment.Value;
                    if (From.ColorAdjustment.Value)
                    {
                        if (From.Brightness.IsSet())
                            Provider.ColorAdjustment.Brightness = EaseFloat(From.Brightness, To.Brightness);

                        if (From.Saturation.IsSet())
                            Provider.ColorAdjustment.Saturation = EaseFloat(From.Saturation, To.Saturation);

                        if (From.Contrast.IsSet())
                            Provider.ColorAdjustment.Contrast = EaseFloat(From.Contrast, To.Contrast);
                    }
                }
            }
        }
    }
}