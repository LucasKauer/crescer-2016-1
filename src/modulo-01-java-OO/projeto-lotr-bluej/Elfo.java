public class Elfo extends Personagem {
    private int flechas = 42;
    private static int numeroDeObjetos;

    public Elfo(String nome) {
        super(nome);
        this.vida = 100;
        Elfo.numeroDeObjetos++;
    }

    // "Destrutor" http://docs.oracle.com/javase/7/docs/api/java/lang/Object.html#finalize%28%29
    protected void finalize() throws Throwable {
        Elfo.numeroDeObjetos--;
        super.finalize();
    }

    public Elfo(String nome, int flechas) {
        this(nome);
        this.flechas = flechas;
    }

    public int getFlechas() {
        return this.flechas;
    }

    public void atirarFlecha(Dwarf dwarf) {
        experiencia++;
        flechas--;
        dwarf.perderVida();
    }

    public String toString() {

        boolean flechaNoSingular = Math.abs(this.flechas) == 1;
        boolean experienciaNoSingular = Math.abs(this.experiencia) == 1;

        return String.format("%s possui %d %s e %d %s de experiência.",
            this.nome,
            this.flechas,
            flechaNoSingular ? "flecha" : "flechas",
            this.experiencia,
            experienciaNoSingular ? "nível" : "níveis");
    }

    public static int getNumeroDeObjetos() {
        return numeroDeObjetos;
    }
    
    public void tentarSorte() {
        System.out.println("Elfo tentou a sorte!");
    }
}