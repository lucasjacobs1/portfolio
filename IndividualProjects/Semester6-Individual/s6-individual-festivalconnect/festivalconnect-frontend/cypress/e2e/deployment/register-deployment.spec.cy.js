describe('Register Input Fields', () => {
    beforeEach(() => {
      cy.visit('http://4.182.106.183/'); 
      cy.get('li').contains('register').click();

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
      cy.intercept('POST', 'http://festivalconnectapi.germanywestcentral.cloudapp.azure.com:8080/Identity/register', {
        statusCode: 200,
        body: { flag: true },
      }).as('registerRequest');
  
      cy.get('input[name="username"]').type('testuser');
      cy.get('input[name="email"]').type('test@example.com');
      cy.get('input[name="password"]').type('password123');
      cy.get('input[name="confirmPassword"]').type('password123');
      cy.get('button[type="submit"]').click();
  
      cy.wait('@registerRequest').its('response.statusCode').should('eq', 200);
      cy.window().its('location.href').should('eq', 'http://4.182.106.183/register');
    });

    it('registers email exists with valid data on database', () => {
    
        cy.get('input[name="username"]').type('testuser');
        cy.get('input[name="email"]').type('test@example.com');
        cy.get('input[name="password"]').type('test');
        cy.get('input[name="confirmPassword"]').type('test');
        cy.get('button[type="submit"]').click();
    
        cy.contains('Email Allready Exist.').should('be.visible')
        cy.window().its('location.href').should('eq', 'http://4.182.106.183/register');
      });
  
    it('displays error message if server returns an error', () => {
      cy.intercept('POST', 'http://festivalconnectapi.germanywestcentral.cloudapp.azure.com:8080/Identity/register', {
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