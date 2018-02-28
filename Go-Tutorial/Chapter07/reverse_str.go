package main

import "fmt"

func reverse(str string) (reverse string){
	s := []byte(str)
	start, end := 0, len(s)-1
	for start<=end{
		a1 := s[start]
		b1 := s[end]
		s[start]=b1
		s[end]=a1
		start = start +1
		end = end-1
	}
	reverse=string(s)
	return
}


func main(){
	str := "gaoeng"
	reverse_str := reverse(str)
	fmt.Printf("original is %s and reverse is %s", str, reverse_str)
}