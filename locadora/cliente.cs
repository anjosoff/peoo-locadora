using System;
class Cliente {
  public int IdCliente { get; set; }
  public string Nome { get; set; }
  public long Cpf { get; set; }
  public string Email { get; set; }
  public override string ToString() {
    return $"ID: {IdCliente}\n{Nome} - {Cpf} - {Email}\n";
  }
}