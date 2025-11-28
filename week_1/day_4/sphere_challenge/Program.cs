using System;
using System.Collections.Generic;
using System.Linq;

public class Sphere
{
  private double radius;

  public double Radius
  {
    get { return radius; }
    set { radius = value > 0 ? value : throw new ArgumentException("Radius must be positive!"); }
  }

  public double Diameter
  {
    get { return radius * 2; }
    set { radius = value > 0 ? value / 2 : throw new ArgumentException("Diameter must be positive!"); }
  }

  public double Volume => (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

  public double SurfaceArea => 4 * Math.PI * Math.Pow(radius, 2);

  public Sphere(double value, bool isDiameter = false)
  {
    if (value <= 0)
      throw new ArgumentException("Value must be positive!");

    radius = isDiameter ? value / 2 : value;
  }

  public override string ToString()
  {
    return $"Sphere [Radius: {radius:F2}, Diameter: {Diameter:F2}, Volume: {Volume:F2}, Surface Area: {SurfaceArea:F2}]";
  }

  public static Sphere operator +(Sphere s1, Sphere s2)
  {
    return new Sphere(s1.Radius + s2.Radius);
  }

  public static bool operator >(Sphere s1, Sphere s2)
  {
    return s1.Volume > s2.Volume;
  }

  public static bool operator <(Sphere s1, Sphere s2)
  {
    return s1.Volume < s2.Volume;
  }

  public static bool operator ==(Sphere s1, Sphere s2)
  {
    if (s1 is null || s2 is null)
      return s1 is null && s2 is null;
    return Math.Abs(s1.Radius - s2.Radius) < 0.0001;
  }

  public static bool operator !=(Sphere s1, Sphere s2)
  {
    return !(s1 == s2);
  }

  public override bool Equals(object obj)
  {
    return obj is Sphere s && this == s;
  }

  public override int GetHashCode()
  {
    return Radius.GetHashCode();
  }

  public Sphere Scale(double factor)
  {
    if (factor <= 0)
      throw new ArgumentException("Scale factor must be positive!");
    return new Sphere(radius * factor);
  }
}

class Program
{
  static void Main()
  {
    Console.WriteLine("=== Sphere Challenge ===\n");

    Sphere s1 = new Sphere(5);
    Sphere s2 = new Sphere(10, isDiameter: true);
    Sphere s3 = new Sphere(7);
    Sphere s4 = new Sphere(5);

    Console.WriteLine("--- Sphere Attributes ---");
    Console.WriteLine(s1);
    Console.WriteLine(s2);
    Console.WriteLine(s3);
    Console.WriteLine(s4);

    Console.WriteLine("\n--- Interchangeable Radius/Diameter ---");
    Console.WriteLine($"S1 Radius: {s1.Radius:F2}, Diameter: {s1.Diameter:F2}");
    s1.Diameter = 14;
    Console.WriteLine($"After setting diameter to 14 - Radius: {s1.Radius:F2}, Diameter: {s1.Diameter:F2}");

    Console.WriteLine("\n--- Adding Spheres ---");
    Sphere combined = s1 + s3;
    Console.WriteLine($"{s1.Radius:F2} + {s3.Radius:F2} = {combined.Radius:F2}");
    Console.WriteLine(combined);

    Console.WriteLine("\n--- Comparing Spheres by Volume ---");
    Console.WriteLine($"S1 > S3? {s1 > s3}");
    Console.WriteLine($"S3 < S1? {s3 < s1}");
    Console.WriteLine($"S2 > S1? {s2 > s1}");

    Console.WriteLine("\n--- Equality Check (by Radius) ---");
    Console.WriteLine($"S1 == S4? {s1 == s4}");
    Console.WriteLine($"S1 != S3? {s1 != s3}");

    Console.WriteLine("\n--- Scaling Spheres ---");
    Sphere scaled = s3.Scale(2);
    Console.WriteLine($"Original: {s3}");
    Console.WriteLine($"Scaled by 2: {scaled}");

    Console.WriteLine("\n--- Sorting Spheres by Radius ---");
    List<Sphere> spheres = new List<Sphere> { s1, s2, s3, s4 };
    Console.WriteLine("Original order:");
    foreach (var s in spheres)
      Console.WriteLine($"  Radius: {s.Radius:F2}");

    spheres.Sort((a, b) => a.Radius.CompareTo(b.Radius));
    Console.WriteLine("\nSorted by radius (ascending):");
    foreach (var s in spheres)
      Console.WriteLine($"  Radius: {s.Radius:F2}");

    Console.WriteLine("\n--- Sorting Spheres by Volume ---");
    spheres.Sort((a, b) => a.Volume.CompareTo(b.Volume));
    Console.WriteLine("Sorted by volume (ascending):");
    foreach (var s in spheres)
      Console.WriteLine($"  Volume: {s.Volume:F2}");

    Console.WriteLine("\n--- Custom Comparer Class ---");
    List<Sphere> spheres2 = new List<Sphere> { s1, s2, s3, s4 };
    spheres2.Sort(new SphereVolumeComparer());
    Console.WriteLine("Sorted by volume using custom comparer:");
    foreach (var s in spheres2)
      Console.WriteLine($"  {s}");

    Console.WriteLine("\nThank you for exploring Spheres!");
  }
}

public class SphereVolumeComparer : IComparer<Sphere>
{
  public int Compare(Sphere s1, Sphere s2)
  {
    return s1.Volume.CompareTo(s2.Volume);
  }
}

public class SphereRadiusComparer : IComparer<Sphere>
{
  public int Compare(Sphere s1, Sphere s2)
  {
    return s1.Radius.CompareTo(s2.Radius);
  }
}
