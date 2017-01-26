# devWarsztaty-Mbank.MatchingService

MatchingService is responsible for matching and quoting lenders that meet quoted criteria to compose an offer for a borrower

Requirements:

- You can only request amount that is less or equal all money on offer
- You can only request amount between 1000 and 15000 inclusive
- You can only request amount that is multiply of 100 ie. `1000, 1100, 1200, ..., 15000`

API Requirements

- Endpoint : /quote
- Verb : POST
- Body of request :

```json
{
    amount: 1000
}
```

- Response :

```json
{
    amountRequested: 1000,
    totalAmounttoRepay:  1008,
    apr: 7.9%
    montlyRepayments: 68.95
}
```

List of aviable lenders

| Name   | APR | Total |
|--------|-----|-------|
| Pawel  | 7.1 | 600   |
| Jakub  | 5.6 | 800   |
| Piotr  | 8.0 | 150   |
| Michal | 4.7 | 200   |
| Ola    | 5.8 | 350   |
| Kasia  | 9.9 | 600   |
| Basia  | 5.8 | 250   |
| Jacek  | 6.1 | 400   |
| Ania   | 7.3 | 350   |
| Tomek  | 5.4 | 900   |
