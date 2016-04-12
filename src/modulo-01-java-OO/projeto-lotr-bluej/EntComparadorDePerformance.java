import java.util.*;

public class EntComparadorDePerformance {

    private final long NUMERO = 1000000; // 1 milhão

    private void metodo1() {
        long resultado = 0;
        for (int i = 1; i <= NUMERO; i++) {
            resultado += i;
        }
        System.out.println("[M1] Soma até " + NUMERO + " = " + resultado);
    }

    private void metodo2() {
        long resultado = NUMERO * (NUMERO + 1) / 2;
        System.out.println("[M2] Soma até " + NUMERO + " = " + resultado);
    }

    public void exibirResultados() {
        long m1Inicio = System.currentTimeMillis();
        metodo1();
        long m1Fim = System.currentTimeMillis();
        double m1Segundos = (m1Fim - m1Inicio) / 1000.0;

        long m2Inicio = System.currentTimeMillis();
        metodo2();
        long m2Fim = System.currentTimeMillis();
        double m2Segundos = (m2Fim - m2Inicio) / 1000.0;

        System.out.println("Usando iteração: " + m1Segundos);
        System.out.println("Usando PA: " + m2Segundos);
    }

    public void exibirResultadosArrayListHashMap() {

        popularArrayListElfos();
        popularHashMapElfos();

        long m1Inicio = System.currentTimeMillis();
        Elfo elfo1 = pesquisarElfoPorNomeArrayList("Elfo nr. 500000000");
        long m1Fim = System.currentTimeMillis();
        double m1Segundos = (m1Fim - m1Inicio) / 1000.0;

        long m2Inicio = System.currentTimeMillis();
        Elfo elfo2 = pesquisarElfoPorNomeHashMap("Elfo nr. 500000000");
        long m2Fim = System.currentTimeMillis();
        double m2Segundos = (m2Fim - m2Inicio) / 1000.0;

        System.out.println("Usando ArrayList: " + m1Segundos);
        System.out.println("Usando HashMap: " + m2Segundos);
    }

    private ArrayList<Elfo> elfos = new ArrayList<>();

    private void popularArrayListElfos() {
        // 1- popular o arraylist
        for (long i = NUMERO; i >= 0; i--) {
            elfos.add(new Elfo("Elfo nr. " + i));
        }
    }

    private Elfo pesquisarElfoPorNomeArrayList(String nome) {
        // 2 - pesquisar
        for (Elfo elfo : elfos) {
            if (elfo.getNome().equals(nome)) {
                return elfo;
            }
        }

        return null;
    }

    private HashMap<String, Elfo> mapaElfos = new HashMap<>();

    private void popularHashMapElfos() {
        for (long i = NUMERO; i >= 0; i--) {
            mapaElfos.put("Elfo nr. " + i, new Elfo("Elfo nr. " + i));
        }
    }

    private Elfo pesquisarElfoPorNomeHashMap(String nome) {
        // 2 - pesquisar
        return mapaElfos.get(nome);
    }
}
