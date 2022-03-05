using System;
class Veiculo{
  private int IdCarro;
  private string modelo;
  private string placa;
  public Veiculo(int idcarro,string modelo, string placa){
    this.IdCarro=IdCarro;
    this.modelo=modelo;
    this.placa=placa;
  }
  public void SetModelo(string modelo){
    this.modelo=modelo;
  }
  public void SetPlaca(string placa){
    this.placa=placa;
  }
  public void SetIdCarro(int idcarro){
    this.IdCarro=idcarro;
  }
  public string GetPlaca(){
    return placa;
  }
  public string GetModelo(){
    return modelo;
  }
  public int GetIdCarro(){
    return IdCarro;
  }
  public override string ToString(){
    return $"ID: {IdCarro}\n Modelo: modelo}\n  Placa:{placa}";
  }
}