package main

import (
	"fmt"
)

func bubble(arr []int){
	for i:=0; i<len(arr); i++{
		for j:=i+1; j<len(arr);j++{
			if arr[j] < arr[j-1]{
				arr[j], arr[j-1] = arr[j-1], arr[j]
			}
		}
	}
}

func main(){
	arr := []int{ 1, 4, 2, 8, 6}
	bubble(arr)
	fmt.Print(arr)
}
