# Test Reto Hash

## Codificación del método Hash
* Identificar condiciones y restricciones de los valores de entrada (cadena de 10 caracteres).
* Codificación del método `Hash`.
* Iterar el ciclo `For` para conocer los diferentes resultados.

## Codificación del método Unhash
* Identificar condiciones y restricciones del valor de entrada (entero positivo).
* El proceso de iteración es a la inversa del método `Hash`, el último número generado por dicho método es la entrada.
  * El resultado de calcular el modulo de 19 del valor de entrada será un entero positivo (índice).
  * Obtener el caracter asociado del diccionario mediante índice obtenido en la última operación.
  * Almacenar el caracter asociado en un arreglo de caracteres.
  * Restar menos 1 a la variable de control de la iteración.

## Notas de desarrollo
* Codificado utilizando Visual Studio 2019
* Lenguaje: C#
* Nombre de la solución: RetoHash

## Tiempo de desarrollo
Apróximadamente 1 hora y media.

## ¿Cómo lo codifique?
Después de observar como el método `Hash` realizaba el cálculo para una cadena conocida `abehinoprs`

> `Hash("abehinoprs") -> 288179037160652`

Observe que la operación pare asignar el nuevo valor al seed:

> `seed = (seed * 19 + diccionario.indexOf(x[i]));`

Generaba los siguientes resultados:
>
```
letra -> resultado - indice
a -> 893 - 0
b -> 16968 - 1
e -> 322394 - 2
h -> 6125489 - 3
i -> 116384295 - 4
n -> 2211301610 - 5
o -> 42014730596 - 6
p -> 798279881331 - 7
r -> 15167317745297 - 8
s -> 288179037160652 - 9
```

La operación agregaba el número correspondiente a la posición donde se encontraba el caracter en el diccionario, de acuerdo a la iteración en curso.
Este valor se puede interpretar posteriormente como un residuo al calcular la división (en el proceso inverso del _Hash_) y de este modo
obtener el caracter del diccionario correspondiente al residuo. Sin embargo, existen ciertos números que se pueden dar un residuo mayor
a la longitud del diccionario por lo que dichos residuos se descartan.

Sin embargo no descubrí esto sin haber intentado calcular `seed % 47` primero, pensando que el 47 era el valor por el cual podia obtener un
residuo, no fue hasta intentar `seed % 19` cuando empece a obtener números enteros correspondientes a los índices para los valores de la
cadena de prueba `abehinoprs`.

A partir de ahí fue fácil construir el método `Unhash` observando que el último valor obtenido por el método `Hash` 
corresponde al último caracter de la cadena resultante por lo que la iteración se ejecuto de manera inversa.


