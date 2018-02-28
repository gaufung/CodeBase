package main

import "fmt"

func whichSeason(month int) (season string) {
	switch {
	case month <= 3:
		season = "Spring"
	case month <= 6:
		season = "Summer"
	case month <= 9:
		season = "Fall"
	case month <= 12:
		season = "winter"
	}
	return
}

func main() {
	month := 4
	fmt.Printf("The month %d is in %s season", month, whichSeason(month))
}
