# Import required namespaces
import clr
clr.AddReference('System.Web.Mvc')
from System.Web.Mvc import *

# The view model class with property
class Message():
    def __init__(self, text):
        self.text = text

# A dynamic action invoker to allow the controller actions to be called appropriately
# due to problems with the reflection of dynamic python types
class DynamicActionInvoker(ControllerActionInvoker) :
    def __init__(self, controller):
        self.controller = controller

    def InvokeAction(self, controllerContext, actionName) :
        self.InvokeActionResult(controllerContext, getattr(self.controller, actionName)())
        return True

# An IronPython implementation of the MessageController inheriting from the base library
# controller type
class MessageController(Controller) :
    def __init__(self):
        self.ActionInvoker = DynamicActionInvoker(self)
    def Index(self):
        return self.View("index", Message("Hello IronPython ASP.NET MVC World!"))