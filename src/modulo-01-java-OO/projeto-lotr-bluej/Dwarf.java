public class Dwarf {
    private int vida = 110;
    private String nome;
    
    public Dwarf(String nome) {
        this.vida = 110;
        this.nome = nome;
    }
    
    public void perderVida() {
        // this.vida = this.vida - 10;
        vida -= 10;
    }
    
    public void setNome(String novoNome) {
        nome = novoNome;
    }
    
    public String getNome() {
        return nome;
    }
    
    // Declarar um objeto:
    // Dwarf gimli = null;
    
    // Criação (instanciação):
    // new Dwarf();
    // Dwarf d1 = new Dwarf();
    
}












