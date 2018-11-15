# ggplot_from_csharp

El siguiente programa genera un archivo .CSV a partir de un set de datos falso, para luego ejecutar R (mediante Cmd y un R-script) con el fin de crear una imagen PNG que integre un grafico de puntos creado con R y la librería GGPLOT2.

## Sobre el proyecto

  *El proyecto corresponde a un proyecto de consola utilizando C# bajo el alero de .Net Framework 4.6. 
  *Para generar el PLOT se utilizo R versión 3.5.1 y las librerias de R GGPLOT2 y TIDYVERSE.
  *Ambos se utilizan bajo un computador con windows 10 de x64. 
  *los output CSV y PNG quedan en la ruta: C:\Users\patricio\Desktop\ggplot_from_csharp\
  *C# genera el CSV
  *R mediante el script ggplot_from_csharp.R crea la imagen PNG a partir del CSV.
  *El script ggplot_from_csharp.r debe estar en la carpeta donde se encuentra Rscript.exe
  *En mi caso: C:\Program Files\R\R-3.5.1\bin\x64
  *El Script de R toma el mismo nombre del archivo CSV para procesarlo. Por ende, si no existe, no creara nada.
  
  
## para ejecutar el proyecto

  * Tener .net  4.6
  * Tener R 3.5.1 
  * Tener instalado ggplot2
  * Tener instalado tidyverse
  
# sobre R
  * <a href="https://cran.r-project.org/bin/windows/base/" target="blank_"> R-3.5.1 for Windows </a>
  
## Librerias de R utilizadas 
  * <a href="https://ggplot2.tidyverse.org/" target="blank_"> GGPLOT2 </a>
  * <a href="https://www.tidyverse.org/" target="blank_"> TIDYVERSE </a>
  
## Detalle del Script 

1) Crear set de datos
2) Tomar set de datos y crear un CSV a partir de ellos.
3) Ejecutar CMD.exe utilizando c# y pasar por parametro nombre del archivo creado para crear png con PLOT desde R.
      
        C:\Program Files\R\R-3.5.1\bin\x64>Rscript.exe ggplot_from_cshar.R nombre_del_archivo_csv_sin_extension

4) Rscript ejecuta ggplot_from_csharp.R y crea imagen png a partir del nombre del csv que se entrego. 

# Output 

El proyecto genera dos archivos.

1)example.csv
2)example.png (a partir de los datos de example.csv)

![alt text](http://patovega.com/github/imagenes/ggplot_from_csharp/ggplot_from_csharp_directory.png)

## example.csv 

![alt text](http://patovega.com/github/imagenes/ggplot_from_csharp/ggplot_from_csharp_example_csv.png)

## example.png

![alt text](http://patovega.com/github/imagenes/ggplot_from_csharp/ggplot_from_csharp_example.png)

