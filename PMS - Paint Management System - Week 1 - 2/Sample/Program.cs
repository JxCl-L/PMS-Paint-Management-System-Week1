using Sample.Enums;
using Sample.Models;

PaintType paintType = PaintType.Basic;

System.Console.WriteLine(paintType);
System.Console.WriteLine((int)paintType);

Paint paint = new Paint(PaintType.HighSheen);
Paint paint2 = new Paint(); // use non-param constructor => set PaintType = unknown

paint.SetPrice(-1);

List<Paint> paints = new List<Paint>();
paints.Add(paint);
paints.Add(paint2);


Order order = new Order(paints);


