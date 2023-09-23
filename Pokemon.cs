using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pokemon : IClassModel
{
    public int Id { get; set; } //this is the same as DexNumber in DB

    public int DexNumber { get; set; }
    public string Name { get; set; }
    public string Form { get; set; }
    public string Type1 { get; set; }
    public string ?Type2 { get; set; }
    public int Total { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefense { get; set; }
    public int Speed { get; set; }
    public int Generation { get; set; }

    public override string ToString()
    {
        return
            $"DexNumber: {DexNumber}\n" +
            $"Name: {Name}\n" +
            $"Form: {Form}\n" +
            $"Type1: {Type1}\n" +
            $"Type2: {Type2}\n" +
            $"Total: {Total}\n" +
            $"HP: {HP}\n" +
            $"Attack: {Attack}\n" +
            $"Defense: {Defense}\n" +
            $"Special Attack: {SpecialAttack}\n" +
            $"Special Defense: {SpecialDefense}\n" +
            $"Speed: {Speed}\n";

    }
}

