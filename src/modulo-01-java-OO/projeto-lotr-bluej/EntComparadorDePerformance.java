public class EntComparadorDePerformance {

    private final long NUMERO = 1000000000; // 1 bilhão

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
}
