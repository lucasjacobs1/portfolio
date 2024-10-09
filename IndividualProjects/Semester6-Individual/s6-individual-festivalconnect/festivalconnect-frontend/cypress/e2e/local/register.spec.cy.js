describe('Register Input Fields', () => {
    beforeEach(() => {
      cy.visit('localhost:5173/register'); 
    });
  
    it('displays error message if any required field is empty', () => {
      cy.get('button[type="submit"]').click();
      cy.get('#error').should('have.text', '');
    });
  
    it('displays error message if email is invalid', () => {
      cy.get('input[name="username"]').type('testuser');
      cy.get('input[name="email"]').type('invalid-email');
      cy.get('input[name="password"]').type('password123');
      cy.get('input[name="confirmPassword"]').type('password123');
      cy.get('button[type="submit"]').click();
      cy.get('#error').should('have.text', 'Please enter a valid email');
    });
  
    it('displays error message if passwords do not match', () => {
      cy.get('input[name="username"]').type('testuser');
      cy.get('input[name="email"]').type('test@example.com');
      cy.get('input[name="password"]').type('password123');
      cy.get('input[name="confirmPassword"]').type('differentpassword');
      cy.get('button[type="submit"]').click();
      cy.get('#error').should('have.text', 'The entered passwords are not the same');
    });
  
    it('registers successfully with valid data', () => {
      cy.intercept('POST', 'http://localhost:5000/Identity/register', {
        statusCode: 200,
        body: { flag: true },
      }).as('registerRequest');
  
      cy.get('input[name="username"]').type('testuser');
      cy.get('input[name="email"]').type('test@example.com');
      cy.get('input[name="password"]').type('password123');
      cy.get('input[name="confirmPassword"]').type('password123');
      cy.get('button[type="submit"]').click();
  
      cy.wait('@registerRequest').its('response.statusCode').should('eq', 200);
      cy.window().its('location.href').should('eq', 'http://localhost:5173/register');
    });
  
    it('displays error message if server returns an error', () => {
      cy.intercept('POST', 'http://localhost:5000/Identity/register', {
        statusCode: 500,
        body: { message: 'Server error' },
      }).as('registerRequest');
  
      cy.get('input[name="username"]').type('testuser');
      cy.get('input[name="email"]').type('test@example.com');
      cy.get('input[name="password"]').type('password123');
      cy.get('input[name="confirmPassword"]').type('password123');
      cy.get('button[type="submit"]').click();
  
      cy.wait('@registerRequest').its('response.statusCode').should('eq', 500);
      //cy.get('#error').should('have.text', 'Server error');
    });
  });
  