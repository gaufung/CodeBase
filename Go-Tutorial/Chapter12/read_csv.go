package main

import (
	"fmt"
	"bufio"
	"os"
	"strings"
	"strconv"
)

type Book struct {
	title string
	price float64
	quantity int
}

func main(){
	var books =make([]Book, 0)
	inputFile, inputError := os.Open("./Chapter12/product.txt")
	if inputError!=nil{
		panic(inputError.Error())
	}

	defer  inputFile.Close()

	inputReader := bufio.NewReader(inputFile)
	for {
		line, readerError := inputReader.ReadString('\n')
		if readerError!=nil{
			break
		}
		line = strings.TrimSpace(line)
		totkes := strings.Split(line, ";")
		title := totkes[0]
		price, err1:= strconv.ParseFloat(totkes[1], 64)
		if err1!=nil{
			fmt.Printf("Error in file:%v\n", err1)
		}
		quantity, err2:=strconv.Atoi(totkes[2])
		if err2!=nil{
			fmt.Printf("Error in file: %v\n", err2)
		}
		books = append(books, Book{title, price, quantity})
	}


	for _, value := range books{
		fmt.Printf("title: %s; price: %f; quantity: %d\n", value.title, value.price, value.quantity)
	}
}
