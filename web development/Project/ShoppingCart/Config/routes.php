<?php
/**
 * Route -> namespace of the route.
 * Use lowercase for keys.
 */

const GOES_TO = 'goesTo';
const METHODS = 'methods';
const REQUEST_METHOD = 'requestMethod';
const NS = 'namespace';
const CONTROLLERS = 'controllers';

// Default
$config['*'][NS] = 'Controllers';

// Home
$config['*'][CONTROLLERS]['home'][GOES_TO] = 'index';
$config['*'][CONTROLLERS]['home'][METHODS]['new'] = 'index';
$config['*'][CONTROLLERS]['home'][REQUEST_METHOD]['new'] = 'post';

// Login
$config['*'][CONTROLLERS]['home'][METHODS]['login'] = 'login';
$config['*'][CONTROLLERS]['home'][REQUEST_METHOD]['login'] = 'post';

// Register
$config['*'][CONTROLLERS]['home'][METHODS]['register'] = 'register';
$config['*'][CONTROLLERS]['home'][REQUEST_METHOD]['register'] = 'post';

// Logout
$config['*'][CONTROLLERS]['home'][METHODS]['logout'] = 'logout';

// Administration panel
$config['Admin/users'][NS] = 'Controllers\something';

$config['Admin'][NS] = 'Controllers\Admin';
$config['Admin'][CONTROLLERS]['index'][GOES_TO] = 'index';
$config['Admin'][CONTROLLERS]['index'][METHODS]['index'] = 'index';
$config['Admin'][CONTROLLERS]['index'][METHODS]['new'] = 'create';
$config['Admin'][CONTROLLERS]['index'][REQUEST_METHOD]['new'] = 'post';

return $config;