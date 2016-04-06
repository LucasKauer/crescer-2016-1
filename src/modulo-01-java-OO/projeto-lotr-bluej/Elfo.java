public class Elfo {
    private String nome;
    private int experiencia, flechas = 42;
    
    public Elfo(String nome) {
        this.nome = nome;
    }
    
    public int getFlechas() {
        return this.flechas;
    }
    
    public int getExperiencia() {
        return this.experiencia;
    }
    
    public String getNome() {
        return this.nome;
    }
    
    public void atirarFlecha(Dwarf dwarf) {
        experiencia++;
        flechas--;
        dwarf.perderVida();
    }
}