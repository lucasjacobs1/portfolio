/// <reference types="Cypress" />

describe('Login', () => {
  beforeEach(() => {
    cy.visit('http://localhost:3000')
  })

  it('shows error message for invalid login with invalid password', () => {
    cy.get('[id="username"]').type('LucasJacobs')
    cy.get("input[type='password']").type('invalidpassword')
    cy.get('button').click()
    cy.get('[id="error-message"]', {timeout: 5000}).should('have.text', 'Password is incorrect')
  })

  it('shows error message for invalid login with invalid username', () => {
    cy.get('[id="username"]').type('InvalidUsername')
    cy.get("input[type='password']").type('Test')
    cy.get('button').click()
    cy.get('[id="error-message"]', {timeout: 5000}).should('have.text', 'Username is incorrect')
  })


  it('logs in successfully with valid username and password', () => {
    cy.get('[id="username"]').type('LucasJacobs');
    cy.get("input[type='password']").type('Test');
    cy.get("button[type='submit']").click();
    cy.url().should('eq', 'http://localhost:3000/')

  })
})

/*describe('Register', () => {
  beforeEach(() => {
    cy.visit('http://localhost:3000/register')
  })

  it('registers successfully with valid input', () => {
    cy.get('[id="userName"]').type('test');
    cy.get('[id="firstName"]').type('test');
    cy.get('[id="lastName"]').type('test');
    cy.get('[id="email"]').type('test@test.com');
    cy.get('[id="gender"]').select(0)
    cy.get('[id="birthday"]').click()
    cy.get("input[type='date']").type('2000-12-12').click()
    cy.get('[id="password"]').type('validpassword')
    cy.get('button').click()
    cy.url().should('eq', 'http://localhost:3000/login')
  })

})*/


describe('logout', () => {
  beforeEach(() => {
  })

  it('logout', () => {
    cy.visit('http://localhost:3000/login')

    cy.get('[id="username"]').type('LucasJacobs');
    cy.get("input[type='password']").type('Test');
    cy.get("button[type='submit']").click();
 
    cy.get("[id='logout']").click()
    cy.stub(window, 'confirm').returns(true);

    cy.url().should('eq', 'http://localhost:3000/login')
  })
})





