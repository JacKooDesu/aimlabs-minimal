var ALM = CS.ALM;
var CrosshairPanel = ALM.Screens.Base.CrosshairPanel;
var OriginBindalbe = ALM.Util.UIToolkitExtend.OriginBindalbe;
var Elements = ALM.Util.UIToolkitExtend.Elements;
var Creator = ALM.Util.Texturing.Creator;
var Drawer = ALM.Util.Texturing.Drawer;
var Setting = CrosshairPanel.OptionSetting;
var SliderIntBind = OriginBindalbe.SliderInt;
var ColorBind = Elements.ColorBindElement.RgbaBindable;
const arr = CS.System.Array.CreateInstance(puer.$typeof(CS.ALM.Util.UIToolkitExtend.Bindable), 7);
const DefaultColor = CS.UnityEngine.Color.green;
var inner = new OriginBindalbe.SliderInt(0, 50, 0);
inner.DataPath = "inner";
inner.Label = "Inner";
var outer = new SliderIntBind(0, 50, 5);
outer.DataPath = "outer";
outer.Label = "Outer";
var thickness = new SliderIntBind(0, 20, 2);
thickness.DataPath = "thickness";
thickness.Label = "Thickness";
var color = new ColorBind(DefaultColor);
color.DataPath = "color";
color.Label = "Color";
var outerCircle = new SliderIntBind(0, 120, 0);
outerCircle.DataPath = "outer-circle";
outerCircle.Label = "Outer Circle";
var innerCircle = new SliderIntBind(0, 120, 0);
innerCircle.DataPath = "inner-circle";
innerCircle.Label = "Inner Circle";
var circleColor = new ColorBind(DefaultColor);
circleColor.DataPath = "circleColor";
circleColor.Label = "circleColor";
var drawer = new Drawer(Creator.New(256, 256));
var _arr = [
    inner,
    outer,
    thickness,
    color,
    outerCircle,
    innerCircle,
    circleColor,
];
export function binding() {
    _arr.forEach((b, i) => arr.SetValue(b, i));
    let setting = new Setting();
    setting.Bindables = arr;
    return setting;
}
export function create() {
    return drawer.Tex;
}
export function render(texture) {
    drawer.Clear();
    drawer.SetOffset(128, 128);
    drawer.Rectangle(-thickness.Value, inner.Value, 0, outer.Value, color.Value);
    drawer.Rectangle(-inner.Value, 0, -outer.Value, thickness.Value, color.Value);
    drawer.SymmetryLeftRight(0);
    drawer.SymmetryTopBottom(0);
    if (outerCircle.Value > 0 && outerCircle.Value > innerCircle.Value) {
        drawer.Donut(0, 0, outerCircle.Value, innerCircle.Value, circleColor.Value);
    }
    drawer.Apply();
}
//# sourceMappingURL=corsshair-config.cjs.map