package main

import "testing"

func TestDelete(t *testing.T) {
	word := "test"
	dictionary := Dictionary{word: "test definition"}

	dictionary.Delete(word)

	_, err := dictionary.Search(word)
	if err != ErrNotFound {
		t.Errorf("Expected %q to be deleted", word)
	}
}

func TestUpdate(t *testing.T) {

	t.Run("existing word", func(t *testing.T) {
		word := "test"
		difinition := "this is just a test"
		newDifinition := "new difinition"
		dictionary := Dictionary{word: difinition}

		err := dictionary.Update(word, newDifinition)

		assertError(t, err, nil)
		assertDefinition(t, dictionary, word, newDifinition)
	})

	t.Run("new word", func(t *testing.T) {
		word := "test"
		difinition := "this is just a test"
		dictionary := Dictionary{}

		err := dictionary.Update(word, difinition)

		assertError(t, err, ErrWordDoesNotExist)
	})
}

func TestAdd(t *testing.T) {
	t.Run("new word", func(t *testing.T) {
		dictionary := Dictionary{}
		word := "test"
		difinition := "this is just a test"

		err := dictionary.Add(word, difinition)

		assertError(t, err, nil)
		assertDefinition(t, dictionary, word, difinition)
	})

	t.Run("existing word", func(t *testing.T) {
		word := "test"
		difinition := "this is just a test"
		dictionary := Dictionary{word: difinition}
		err := dictionary.Add(word, "new test")

		assertError(t, err, ErrWordExists)
		assertDefinition(t, dictionary, word, difinition)
	})
}

func TestSearch(t *testing.T) {
	dictionary := Dictionary{"test": "this is just a test"}

	t.Run("known word", func(t *testing.T) {
		got, _ := dictionary.Search("test")
		want := "this is just a test"

		assertStrings(t, got, want)
	})

	t.Run("unknown word", func(t *testing.T) {
		_, err := dictionary.Search("unknown")
		want := "could not find the word you were looking for"

		assertError(t, err, ErrNotFound)
		assertStrings(t, err.Error(), want)
	})
}

func assertDefinition(t testing.TB, dictionary Dictionary, word, difinition string) {
	t.Helper()

	got, err := dictionary.Search(word)
	if err != nil {
		t.Fatal("should find added word:", err)
	}

	if difinition != got {
		t.Errorf("got %q want %q", got, difinition)
	}
}

func assertStrings(t testing.TB, got, want string) {
	t.Helper()

	if got != want {
		t.Errorf("got %q want %q", got, want)
	}
}

func assertError(t testing.TB, got, want error) {
	t.Helper()

	if got != want {
		t.Errorf("got error %q want %q", got, want)
	}
}
