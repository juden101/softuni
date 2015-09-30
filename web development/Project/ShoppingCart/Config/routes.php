<?php
/**
 * Route -> namespace of the route.
 * Use lowercase for keys.
 */

const GOES_TO = 'goesTo';
const METHODS = 'methods';
const NS = 'namespace';
const CONTROLLERS = 'controllers';

// Default
$config['*'][NS] = 'Controllers';

// Administration panel
$config['Admin/users'][NS] = 'Controllers\something';

$config['Admin'][NS] = 'Controllers\Admin';
$config['Admin'][CONTROLLERS]['index2'][GOES_TO] = 'index';
$config['Admin'][CONTROLLERS]['index2'][METHODS]['new'] = 'create';
$config['Admin'][CONTROLLERS]['user'][GOES_TO] = 'some_dude';
$config['Admin'][CONTROLLERS]['user'][METHODS]['create'] = 'some_create';

return $config;