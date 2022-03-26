using System;
using System.Collections.Generic;
public class Cliente: IComparable<Cliente> {
  public int IdCliente { get; set; }
  public string Nome { get; set; }
  public long Cpf { get; set; }
  public string Email { get; set; }
  public override string ToString() {
    return $"ID: {IdCliente}\n{Nome} - {Cpf} - {Email}\n";
  }
   public int CompareTo(Cliente obj){
    return Nome.CompareTo(obj.Nome);
  }
}