package main

import (
	"testing"
)

func TestWallet(t *testing.T) {

	t.Run("Deposit", func(t *testing.T) {
		wallet := Wallet{}
		wallet.Deposit(Bitcoin(10))

		assertBalance(t, wallet, Bitcoin(10))
	})

	t.Run("Withdraw with funds", func(t *testing.T) {
		wallet := Wallet{balance: Bitcoin(20)}
		err := wallet.Withdraw(Bitcoin(10))

		assertBalance(t, wallet, Bitcoin(10))
		assertNoError(t, err)
	})

	t.Run("Withdraw insufficient funds", func(t *testing.T) {
		startingBalance := Bitcoin(20)
		wallet := Wallet{balance: startingBalance}
		err := wallet.Withdraw(Bitcoin(100))

		assertBalance(t, wallet, startingBalance)
		assertError(t, err, "cannot withdraw, insufficient funds")
	})
}

func TestString(t *testing.T) {
	got := Bitcoin(10).String()
	want := "10 BTC"

	if got != want {
		t.Errorf("got %s want %s", got, want)
	}
}

func assertBalance(t testing.TB, wallet Wallet, want Bitcoin) {
	t.Helper()
	got := wallet.Balance()

	if got != want {
		t.Errorf("got %s want %s", got, want)
	}
}

func assertNoError(t testing.TB, got error) {
	t.Helper()
	if got != nil {
		t.Fatal("got an error but didn't want one")
	}
}

func assertError(t testing.TB, got error, want string) {
	t.Helper()
	if got == nil {
		t.Fatal("didn't get an error but wanted one")
	}

	if got.Error() != want {
		t.Errorf("got %q, want %q", got, want)
	}
}