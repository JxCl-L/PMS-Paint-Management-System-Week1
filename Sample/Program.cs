using Sample.Models;

PaintProduct paint1 = new PaintProduct("底漆", Sample.Enums.PaintType.BaseCoat, new PaintSpecification("Blue", 300), 140.6m);
PaintProduct paint2 = new PaintProduct("高光漆", Sample.Enums.PaintType.Glossy, new PaintSpecification("Grey", 200), 123.2m);
PaintProduct paint3 = new PaintProduct("哑光漆", Sample.Enums.PaintType.Matte, new PaintSpecification("Black", 100), 230.59m);

System.Console.WriteLine("Displaying Paint Info:");
paint1.DisplayInfo();
paint2.DisplayInfo();
paint3.DisplayInfo();

Order order = new Order(paint1, 35);

System.Console.WriteLine("\nDisplaying Order Info:");
order.DisplayOrder();


