const arr = CS.System.Array.CreateInstance(
  puer.$typeof(CS.ALM.Util.UIToolkitExtend.Bindable),
  7
) as CS.System.Array$1<CS.ALM.Util.UIToolkitExtend.Bindable>;

const V2Int = CS.UnityEngine.Vector2Int;
const Setting = CS.ALM.Screens.Base.CrosshairPanel.OptionSetting;
const Drawer = CS.ALM.Util.Texturing.Drawer;
const SliderIntBind = CS.ALM.Util.UIToolkitExtend.OriginBindalbe.SliderInt;
const ToggleBind = CS.ALM.Util.UIToolkitExtend.OriginBindalbe.Toggle;
const ColorBind =
  CS.ALM.Util.UIToolkitExtend.Elements.ColorBindElement.RgbaBindable;
const DefaultColor = CS.UnityEngine.Color.green;

type ColorElement = CS.ALM.Util.UIToolkitExtend.Elements.ColorBindElement;
type Toggle = CS.UnityEngine.UIElements.Toggle;
type SliderInt = CS.UnityEngine.UIElements.SliderInt;

var inner = new SliderIntBind(0, 50, 0);
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

var drawer = new Drawer(CS.ALM.Util.Texturing.Creator.New(256, 256));

export function binding() {
  arr.SetValue(inner, 0);
  arr.SetValue(outer, 1);
  arr.SetValue(thickness, 2);
  arr.SetValue(color, 3);
  arr.SetValue(outerCircle, 4);
  arr.SetValue(innerCircle, 5);
  arr.SetValue(circleColor, 6);
  let setting = new Setting();
  setting.Bindables = arr;
  return setting;
}

export function create() {
  return drawer.Tex;
}

export function render(texture: CS.UnityEngine.Texture2D) {
  drawer.Clear();
  drawer.SetOffset(128, 128);

  // up
  drawer.Rectangle(-thickness.Value, inner.Value, 0, outer.Value, color.Value);

  //left
  drawer.Rectangle(-inner.Value, 0, -outer.Value, thickness.Value, color.Value);

  drawer.SymmetryLeftRight(0);
  drawer.SymmetryTopBottom(0);

  if (outerCircle.Value > 0 && outerCircle.Value > innerCircle.Value) {
    drawer.Donut(0, 0, outerCircle.Value, innerCircle.Value, circleColor.Value);
  }

  drawer.Apply();
}
