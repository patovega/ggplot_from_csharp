#this file must be save in the folder of the rScript.exe
#example: C:\\Program Files\\R\\R-3.5.1\\bin\\x64\\

#the cmd pass args by command
#for this example received a filename = args[1]
args = commandArgs(trailingOnly=TRUE)
#load libs
library(tidyverse)
library(ggplot2)
#set vars
filename <- paste("C:\\Users\\patricio\\Desktop\\ggplot_from_csharp\\", args[1], ".csv",  sep="")
data <- read_csv2(filename)
#subset vars A and B
var_a <- subset(data, data[,0:1] == 'A')
var_b <- subset(data, data[,0:1]== 'B')
#create ggplot and create png image
dir <- paste("C:\\Users\\patricio\\Desktop\\ggplot_from_csharp\\", args[1] , ".png",  sep="")
#set dir
png(dir)

p =  ggplot() + 
  geom_point(data = var_a, aes(x = value, y = timestamp, label=name, color = "a"))  + 
  geom_point(data = var_b, aes(x = value, y = timestamp, label=name, color = "b"))

print(p)
dev.off()