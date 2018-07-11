using System;
using System.Collections.Generic;

namespace LUCI {

abstract class Expr {
  
  static class Binary : Expr {
  
    Binary(Expr left, Token operator, Expr right) {
    this.left = left;
    this.Token = Token;
    this.Expr = Expr;
    }

    const Expr left;
    const  Token operator;
    const  Expr right;
  }
  
  static class Grouping : Expr {
  
    Grouping(Expr expression) {
      this.expression = expression;
    }

    const Expr expression;
  }
  
  static class Literal : Expr {
  
    Literal(Object value) {
      this.value = value;
    }

    const Object value;
  }
  
  static class Unary : Expr {
  
    Unary(Token operator, Expr right) {
      this.operator = operator;
      this.Expr = Expr;
    }

    const Token operator;
    const  Expr right;
  }
}