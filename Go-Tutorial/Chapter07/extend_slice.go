package main

import "fmt"
func extend(s []int, factor int)[] int{
	ss := make([]int, len(s), len(s) *factor)
	fmt.Printf("the capacity is %d\n", cap(ss))
	copy(ss, s)
	return ss
}
func main(){
	s := []int{1,2}
	s = extend(s,2)
	fmt.Printf("The length is %d", cap(s))
}
