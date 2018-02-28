package main

func main() {
	subfunc()
}

func subfunc() int {
	bool1 := true
	if bool1 {
		return 1
	} else {
		return 0
	}
}
