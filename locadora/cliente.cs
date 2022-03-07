using System;
class Cliente {
  public int IdCliente { get; set; }
  public string Nome { get; set; }
  public int Cpf { get; set; }
  public string Email { get; set; }
  public override string ToString() {
    return $"{IdCliente} - {Nome} {Cpf}\n {Email}\n";
  }
}