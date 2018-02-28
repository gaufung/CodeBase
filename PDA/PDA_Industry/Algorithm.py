# -*- coding:utf8 -*-
'''
linear programming
lambda min
theta max
'''
from __future__ import division
import logging
from pulp import LpProblem, lpSum, LpVariable, LpMinimize, LpMaximize

def _addelements(sequence, *elements):
    '''
    add elements into list
    '''
    for element in elements:
        sequence.append(element)

def _reciprocal(func):
    def _wrapper(*args, **kw):
        result = func(*args, **kw)
        return [1.0 / x for x in result]
    return _wrapper


def _phi_min(enengies, productions, co2s, energy_right, production_right, co2_right):
    '''
    _lambda_min
    '''
    # the linear programming objective is minimize
    prob = LpProblem("phi_min", LpMinimize)
    variablecount = len(enengies)
    ingredients = [str(symbols + 1) for symbols in range(variablecount)]
    # variable symbols such x1, x2, x3 ... xn
    symbols = LpVariable.dict('x_%s', ingredients, lowBound=0)
    cost = dict(zip(ingredients, enengies))
    prob += lpSum([cost[i] * symbols[i] for i in ingredients])
    pro_dict = dict(zip(ingredients, productions))
    co2_dict = dict(zip(ingredients, co2s))
    # linear constraint condition
    prob += lpSum([pro_dict[i] * symbols[i]
                   for i in ingredients]) >= production_right
    prob += lpSum([co2_dict[i] * symbols[i] for i in ingredients]) == co2_right
    if prob.solve() != 1:
        raise UserWarning
    return prob.objective.value() / energy_right

def _phi_min_feasible(energies, productions, co2s, dmus_right, is_raise_exception=False):
    '''
    phi min feasible solution
    '''
    energies_backup = energies[:]
    productions_backup = productions[:]
    co2s_backup = co2s[:]
    _addelements(energies_backup, 1.0)
    _addelements(productions_backup, 0.0)
    _addelements(co2s_backup, 0.0)
    result = []
    for dmu in dmus_right:
        try:
            result.append(_phi_min(energies_backup, productions_backup, co2s_backup,
                                      dmu.ene.total, dmu.pro.production, dmu.co2.total))
        except UserWarning:
            if is_raise_exception:
                logging.error("unsolve occurs")
                raise Exception
            else:
                result.append(-1.0)
    return result
def _phi_min_infeasible(energies, productions, co2s, dmus_right):
    '''
    lambda min in different years
    '''
    energies_backup = energies[:]
    productions_backup = productions[:]
    co2s_backup = co2s[:]
    _addelements(energies_backup, 1.0, 0.0)
    _addelements(productions_backup, 0.0, 0.0)
    _addelements(co2s_backup, 0.0, -1.0)
    result = []
    for dmu in dmus_right:
        try:
            result.append(_phi_min(energies_backup, productions_backup, co2s_backup,
                                      dmu.ene.total, dmu.pro.production, dmu.co2.total))
        except UserWarning:
            logging.error("unsolve occurs")
            raise Exception
    return result

@_reciprocal
def phi_min(dmus_s, dmus_right, is_same_year=False):
    '''
    the min of energy
    '''
    energies = []
    productions = []
    co2s = []
    for dmus in dmus_s:
        for dmu in dmus:
            energies.append(dmu.ene.total)
            productions.append(dmu.pro.production)
            co2s.append(dmu.co2.total)
    if is_same_year:
        return _phi_min_feasible(energies, productions, co2s, dmus_right, True)
    else:
        result = _phi_min_feasible(energies, productions, co2s, dmus_right, False)
        lambda_differtent = _phi_min_infeasible(energies, productions, co2s, dmus_right)
        for idx, value in enumerate(result):
            if value == -1.0:
                result[idx] = lambda_differtent[idx]
        return result


def _eta_max(enengies, productions, co2s, energy_right, production_right, co2_right):
    '''
    eta max
    '''
    # the linear programming objective is maximize
    prob = LpProblem("eta_max", LpMaximize)
    variablecount = len(enengies)
    ingredients = [str(symbols + 1) for symbols in range(variablecount)]
    # the variable symbols  x1, x2, x3 .... xn
    symbols = LpVariable.dict('x_%s', ingredients, lowBound=0)
    cost = dict(zip(ingredients, productions))
    prob += lpSum([cost[i] * symbols[i] for i in ingredients])
    ene_dict = dict(zip(ingredients, enengies))
    co2_dict = dict(zip(ingredients, co2s))
    prob += lpSum([ene_dict[i] * symbols[i]
                   for i in ingredients]) <= energy_right
    prob += lpSum([co2_dict[i] * symbols[i] for i in ingredients]) == co2_right
    if prob.solve() != 1:
        raise UserWarning
    else:
        return prob.objective.value() / production_right

def _eta_max_feasible(energies, productions, co2s, dmus_right, is_raise_exception=False):
    energies_backup = energies[:]
    productions_backup = productions[:]
    co2s_backup = co2s[:]
    _addelements(energies_backup, 0.0)
    _addelements(productions_backup, -1.0)
    _addelements(co2s_backup, 0.0)
    result = []
    for dmu in dmus_right:
        try:
            result.append(_eta_max(energies_backup, productions_backup, co2s_backup,
                                     dmu.ene.total, dmu.pro.production, dmu.co2.total))
        except UserWarning:
            if is_raise_exception:
                logging.error("unsolve occurs")
                raise Exception
            else:
                result.append(-1.0)
    return result
def _eta_max_infeasible(energies, productions, co2s, dmus_right):
    energies_backup = energies[:]
    productions_backup = productions[:]
    co2s_backup = co2s[:]
    _addelements(energies_backup, 0.0, -1.0)
    _addelements(productions_backup, -1.0, 0.0)
    _addelements(co2s_backup, 0.0, 0.0)
    result = []
    for dmu in dmus_right:
        try:
            result.append(_eta_max(energies_backup, productions_backup, co2s_backup,
                                     dmu.ene.total, dmu.pro.production, dmu.co2.total))
        except UserWarning:
            logging.error("unsolve occurs")
            raise Exception
    return result

@_reciprocal
def eta_max(dmus_s, dmus_right, is_same_year=False):
    '''
    the production max
    '''
    energies = []
    productions = []
    co2s = []
    for dmus in dmus_s:
        for dmu in dmus:
            energies.append(dmu.ene.total)
            productions.append(dmu.pro.production)
            co2s.append(dmu.co2.total)
    # add slack variables
    if is_same_year:
        return _eta_max_feasible(energies, productions, co2s, dmus_right, True)
    else:
        result = _eta_max_feasible(energies, productions, co2s, dmus_right, False)
        theta_different = _eta_max_infeasible(energies, productions, co2s, dmus_right)
        for idx, value in enumerate(result):
            if value == -1.0:
                result[idx] = theta_different[idx]
        return result
